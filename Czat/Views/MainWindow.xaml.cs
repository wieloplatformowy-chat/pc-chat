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
        private UserDTO _me = new UserDTO();
        private UserDTO _currentSender = new UserDTO();
        private UserDTO _previousSender = new UserDTO();
        private Dictionary<string, string> _emoteDictionary;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDictionary();
            System.IO.Directory.SetCurrentDirectory(@"..\..\");
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
        private void SendMsg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextOfMsg.Text))
                return;

            AddMessage(TextOfMsg.Text, _me.Id);
            TextOfMsg.Text = null;
        }

        /// <summary>
        /// Adds new message
        /// </summary>
        /// <param name="message">Contents of message</param>
        /// <param name="senderId">Id of current message sender</param>
        private void AddMessage(string message, long? senderId)
        {
            MessageRow messageRow;

            _currentTime = DateTime.Now;
            _currentSender.Id = senderId;

            bool areTheSameSenders = false;
            bool isNewMessage = true;

            if (_currentSender.Id == _previousSender.Id)
                areTheSameSenders = true;

            _timeRange = _currentTime - _previousTime;

            // Checks if new or merged message
            if (_timeRange.TotalSeconds <= MergeInterval && areTheSameSenders) 
                isNewMessage = false;

            if (isNewMessage)
            {
                messageRow = new MessageRow(senderId == _me.Id) {
                    AdditionalInfo = _currentTime.ToString("HH:mm"),
                    AvatarSource = CreateImage(_emoteDictionary[":D"]).Source
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
            ScrollContentToBottom(senderId == _me.Id);

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
            else if (maxVerticalOffset < 0 || verticalOffset == maxVerticalOffset)
                ChatScrollViewer.ScrollToBottom();
        }

        /// <summary>
        /// Splits message by emoticons including them
        /// </summary>
        /// <param name="message">Content of the message</param>
        /// <returns>Slices of the message</returns>
        private static IEnumerable<string> SplitMessageByEmoticons(string message) 
        {
            const string pattern = @"((?::|;|>)\S+)"; // All texts starting with : or ; or > up to whitespace
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
                    var img = CreateImage(_emoteDictionary[element]);
                    messageControl.AppendMessage(img);
                }
                else
                    messageControl.AppendMessage(element);
            }
        }

        /// <summary>
        /// Creates Image object loading proper emoticon icon
        /// </summary>
        /// <param name="uri">Path to the emoticons directory</param>
        /// <returns>Emoticon image</returns>
        private static Image CreateImage(string uri)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Environment.CurrentDirectory + @"\Resources\img\" + uri); // TODO change to embedded resource
            bitmap.EndInit();

            return new Image
            {
                Source = bitmap,
                Height = 18,
                Width = 18
            };
        }

        /// <summary>
        /// Opens or closes popup window with emoticons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseEmote_Click(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = !Popup1.IsOpen;
        }

        /// <summary>
        /// Inserts emoticon clicked in popup window into text of message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Emote_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += ((ContentControl) sender).Content + " ";
            Popup1.IsOpen = false;
            TextOfMsg.Focus();
            TextOfMsg.SelectionStart = TextOfMsg.Text.Length;
        }
    }
}
