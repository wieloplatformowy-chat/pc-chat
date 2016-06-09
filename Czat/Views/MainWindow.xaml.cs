using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using Czat.Helpers;
using RestApiService.Model;

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
        private MessageControl _lastMessageControls;
        private bool _toOpen = true;
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
                {":'(", "EmoteCry.png"}
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
            MessageControl messageControl;

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
                messageControl = ChatElementsHelper.GetMessageControl(senderId == _me.Id);
                messageControl.ChangeDateTimeContent(_currentTime.ToString("HH:mm"));
                ChatPanel.Children.Add(messageControl.Control);
                _lastMessageControls = messageControl;
            }
            else
            {
                message = "\n" + message;
                messageControl = _lastMessageControls;
            }

            string[] splittedMessage = SplitMessage(message);
            AddToMessageControl(splittedMessage, messageControl);

            _previousTime = _currentTime;
            _previousSender = _currentSender;
        }

        /// <summary>
        /// Adds text of message or emoticon image to MessageControl
        /// </summary>
        /// <param name="splittedMessage"></param>
        /// <param name="messageControl"></param>
        private void AddToMessageControl(string[] splittedMessage, MessageControl messageControl)
        {
            foreach (var element in splittedMessage)
            {
                if (_emoteDictionary.ContainsKey(element))
                {
                    var img = CreateImage(_emoteDictionary[element]);
                    messageControl.AddMessage(img);
                }
                else
                    messageControl.AddMessage(element);
            }
        }

        /// <summary>
        /// Creates Image object loading proper emoticon icon
        /// </summary>
        /// <param name="uri">Path to the emoticons directory</param>
        /// <returns>Emoticon image</returns>
        private Image CreateImage(string uri)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Environment.CurrentDirectory + @"\Resources\img\" + uri);
            bitmap.EndInit();

            var img = new Image
            {
                Source = bitmap,
                Height = 18,
                Width = 18
            };

            return img;
        }

        /// <summary>
        /// Splits message by emoticons including them
        /// </summary>
        /// <param name="message">Contents of message</param>
        /// <returns>Table of splitted message</returns>
        private string[] SplitMessage(string message)
        {
            string pattern = @"(:\)) | (;\)) | (:\D) | (:\/) | (:\() | (:\|) | (:'\()";
            string[] partsOfMessage = System.Text.RegularExpressions.Regex.Split(message, pattern, System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace);

            return partsOfMessage;
        }

        /// <summary>
        /// Opens or closes popup window with emoticons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseEmote_Click(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = _toOpen;
            _toOpen = !_toOpen;
        }

        /// <summary>
        /// Inserts emoticon clicked in popup window into text of message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Emote_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += ((ContentControl)sender).Content.ToString();
            Popup1.IsOpen = false;
            TextOfMsg.Focus();
            TextOfMsg.SelectionStart = TextOfMsg.Text.Length;
        }
    }
}
