using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using RestApiService.Model;
using System.Text.RegularExpressions;
using Czat.Controls;
using RestApiService;
using RestApiService.Services;
using Czat.Helpers;
using System.IO;
using System.Reflection;

namespace Czat.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Time in seconds after which messages of the same sender are written separately
        /// </summary>

        private const double MergeInterval = 15;

        private DateTime _currentTime;
        private DateTime _previousTime;
        private TimeSpan _timeRange;
        private MessageRow _lastMessageRow;
        private ContactListContactData _me;
		private ContactListContactData _myFriend;
        private ContactListContactData _currentSender;
        private ContactListContactData _previousSender;
        private Dictionary<string, string> _emoteDictionary;

        public ConversationRestService ConversationService { get; }
        public MessageRestService MessageService { get; }

        private ConversationsResponse _conversationResponse;
        private IList<MessageModel> _messages;
        private readonly List<MessageModel> _messagesToUpdate;
        private long? _lastReceivedMsg;
        private readonly Dictionary<long?, BitmapImage> _avatars;
        private readonly string _imagesDirectoryPath;

        public MainWindow(ContactListContactData currentUser, ContactListContactData friend)
        {
            ConversationService = IoC.Resolve<ConversationRestService>();
            MessageService = IoC.Resolve<MessageRestService>();
            InitializeComponent();
            InitializeDictionary();
            GetConversationAndMessages(currentUser, friend);
            _messagesToUpdate = new List<MessageModel>();
            _avatars = new Dictionary<long?, BitmapImage>();

            var location = Assembly.GetEntryAssembly().Location;
            _imagesDirectoryPath = Path.GetDirectoryName(location) + @"\Resources\img\";
        }

        private void InitializeDictionary()
        {
            _emoteDictionary = new Dictionary<string, string>
            {
                {":)", "EmoteSmile.png"},
                {";)", "EmoteWinkSmile.png"},
                {":D", "EmoteGrin.png"},
                {":|", "EmoteSerious.png"},
                {":/", "EmoteUnsure.png"},
                {":(", "EmoteSad.png"},
                {":'(", "EmoteCry.png"},
                {":O", "EmoteWonder.png"},
                {">:(", "EmoteAngry.png"}
            };
        }

        private async void GetConversationAndMessages(ContactListContactData currentUser, ContactListContactData friend)
        {
            _me = currentUser;
            _myFriend = friend;
         
            _conversationResponse = await ConversationService.GetConversationWithUser(friend.Id);
            _messages = await MessageService.Get20LastMessages(_conversationResponse.Id);

            foreach (var message in _messages)
            {
                AddMessageToReconstructConversation(
                    message.Message, 
                    _me.Id == message.UserId ? _me : _myFriend,
                    message.Date, 
                    message.Id
                );
            }
        }

        public async void UpdateConversation()
        {
            _messagesToUpdate.Clear();
            _messages = await MessageService.Get20LastMessages(_conversationResponse.Id);

            for (int i = _messages.Count - 1; i > 0; i--)
            {
                if (_messages[i].UserId == _myFriend.Id)
                {
                    if (_messages[i].Id > _lastReceivedMsg)
                        _messagesToUpdate.Add(_messages[i]);
                    else
                        return;
                }
            }

            foreach (var message in _messages)
            {
                if (_me.Id == message.UserId)
                    AddMessageToReconstructConversation(message.Message, _me, message.Date, message.Id);
                else
                    AddMessageToReconstructConversation(message.Message, _myFriend, message.Date, message.Id);
            }
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SendMsg.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        /// <summary>
        /// Send button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SendMsg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextOfMsg.Text))
                return;

            AddMessage(TextOfMsg.Text, _me, DateTime.Now);
            await MessageService.SendMessage(_conversationResponse.Id, TextOfMsg.Text);
            TextOfMsg.Text = null;
        }

        /// <summary>
        /// Adds new message
        /// </summary>
        /// <param name="message">Contents of message</param>
        /// <param name="sender">Id of current message sender</param>
        private void AddMessage(string message, ContactListContactData sender, DateTime sendTime)
        {
            MessageRow messageRow;

            _currentTime = sendTime;
            _currentSender = sender;

            bool areTheSameSenders = false;
            bool isNewMessage = true;

            if (_currentSender == _previousSender)
                areTheSameSenders = true;

            _timeRange = _currentTime - _previousTime;

            // Checks if new or merged message
            if (_timeRange.TotalSeconds <= MergeInterval && areTheSameSenders) 
                isNewMessage = false;

            if (isNewMessage)
            {
                messageRow = new MessageRow(sender == _me) {
                    AdditionalInfo = _currentTime.ToString("HH:mm"),
                    AvatarSource = GetAvatar(sender)
                };
                ChatPanel.Children.Add(messageRow);
                _lastMessageRow = messageRow;
            }
            else
            {
                message = "\n" + message;
                messageRow = _lastMessageRow;
            }

            AddFormattedMessage(messageRow, message);
            ScrollContentToBottom(sender == _me);

            _previousTime = _currentTime;
            _previousSender = _currentSender;
        }

        /// <summary>
        /// Scrolls vertically to the most recent message
        /// </summary>
        /// <param name="isLocal">Checks who sent the message</param>
        private void ScrollContentToBottom(bool isLocal = true)
        {
            var verticalOffset = ChatScrollViewer.VerticalOffset;
            var maxVerticalOffset = ChatScrollViewer.ExtentHeight - ChatScrollViewer.ViewportHeight;

            if (isLocal)
                ChatScrollViewer.ScrollToBottom();
            else if (maxVerticalOffset < 0 || Math.Abs(verticalOffset - maxVerticalOffset) < .5)
                ChatScrollViewer.ScrollToBottom();
        }

        /// <summary>
        /// Splits message by emoticons including them
        /// </summary>
        /// <param name="message">Content of the message</param>
        /// <returns>Slices of the message</returns>
        private static IEnumerable<string> SplitMessageByEmoticons(string message) 
        {
            const string pattern = @"((?::|;|>:)\S+)"; // All texts starting with : or ; or >: up to whitespace
            return Regex.Split(message, pattern);
        }
		
        /// <summary>
        /// Adds text of message or emoticon image to MessageControl
        /// </summary>
        /// <param name="messageControl">MessageControl to add the text to</param>
        /// <param name="message">Content of the message</param>
        private void AddFormattedMessage(MessageRow messageControl, string message)
        {
            var splittedMessage = SplitMessageByEmoticons(message);
            foreach (var element in splittedMessage)
            {
                if (_emoteDictionary.ContainsKey(element))
                {
                    Image img = CreateImage(_emoteDictionary[element]);
                    messageControl.AppendMessage(img);
                }
                else
                    messageControl.AppendMessage(element);
            }
        }

        private Image CreateImage(string uri)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(_imagesDirectoryPath + uri);
            bitmap.EndInit();
            return new Image
            {
                Source = bitmap,
                Height = 18,
                Width = 18
            };
        }

        private BitmapImage GetAvatar(ContactListContactData contact)
        {
            if (_avatars.ContainsKey(contact.Id))
            {
                return _avatars[contact.Id];
            }
            else
            {
                string hash = GravatarHelper.HashEmailForGravatar(contact.Email);
                BitmapImage avatar = GravatarHelper.GetGravatarImage(string.Format("http://www.gravatar.com/avatar/{0}?size=40", hash));
                _avatars.Add(contact.Id, avatar);
                return avatar;
            }
        }

        /// <summary>
        /// Opens popup window with emoticons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseEmote_Click(object sender, RoutedEventArgs e)
        {
            EmotePopup.IsOpen = !EmotePopup.IsOpen;
        }

        /// <summary>
        /// Inserts emoticon clicked in popup window into text of message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Emote_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += ((ContentControl) sender).Content + " ";
            EmotePopup.IsOpen = false;
            TextOfMsg.Focus();
            TextOfMsg.SelectionStart = TextOfMsg.Text.Length;
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddMessageToReconstructConversation(string message, ContactListContactData sender, long? sendTime, long? messageId)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime lastMsgDate = start.AddMilliseconds((double)sendTime).ToLocalTime();

            AddMessage(message, sender, lastMsgDate);

            _lastReceivedMsg = messageId;
        }
    }
}
