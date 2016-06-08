using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;
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
        private const double MergeInterval = 30;

        private DateTime _currentTime;
        private DateTime _previousTime;
        private TimeSpan _timeRange;
        private Paragraph _messageParagraph;
        private Paragraph _dateTimeParagraph;
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
        /// Gets message paragraph
        /// </summary>
        /// <param name="isNewNeeded">Checks if new paragraph is needed</param>
        /// <param name="senderId">Id of current message sender</param>
        /// <returns>Paragraph</returns>
        private Paragraph GetMessageParagraph(bool isNewNeeded, long? senderId)
        {
            if (_messageParagraph != null && !isNewNeeded)
                return _messageParagraph;

            _messageParagraph = new Paragraph();
            _messageParagraph.FontSize = 12;

            if (senderId == _me.Id)
            {
                _messageParagraph.Background = System.Windows.Media.Brushes.DarkCyan;
                _messageParagraph.Foreground = System.Windows.Media.Brushes.White;
                _messageParagraph.TextAlignment = TextAlignment.Right;
            }
            else
            {
                _messageParagraph.Background = System.Windows.Media.Brushes.LightGray;
                _messageParagraph.TextAlignment = TextAlignment.Left;
            }

            return _messageParagraph;
        }

        /// <summary>
        /// Gets date time paragraph
        /// </summary>
        /// <param name="isNewNeeded">Checks if new paragraph is needed</param>
        /// <param name="senderId">Id of current message sender</param>
        /// <returns>Paragraph</returns>
        private Paragraph GetDateTimeParagraph(bool isNewNeeded, long? senderId)
        {
            if (_dateTimeParagraph != null && !isNewNeeded)
                return _dateTimeParagraph;

            _dateTimeParagraph = new Paragraph();
            _dateTimeParagraph.FontSize = 8;

            if (senderId == _me.Id)
                _dateTimeParagraph.TextAlignment = TextAlignment.Right;
            else
                _dateTimeParagraph.TextAlignment = TextAlignment.Left;

            return _dateTimeParagraph;
        }

        /// <summary>
        /// Adds new message
        /// </summary>
        /// <param name="message">Contents of message</param>
        /// <param name="senderId">Id of current message sender</param>
        private void AddMessage(string message, long? senderId)
        {
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

            GetMessageParagraph(isNewMessage, _currentSender.Id);
            GetDateTimeParagraph(isNewMessage, _currentSender.Id);

            if (isNewMessage)
            {
                //document.Blocks.Add(messageParagraph);
                //document.Blocks.Add(dateTimeParagraph);
                _dateTimeParagraph.Inlines.Add(new Run(_currentTime.ToString("HH:mm")));
            }
            else
                message = "\n" + message;

            string[] splittedMessage = SplitMessage(message);
            AddToParagraph(splittedMessage);

            _previousTime = _currentTime;
            _previousSender = _currentSender;
        }

        /// <summary>
        /// Adds text of message or emoticon image to paragraph
        /// </summary>
        /// <param name="splittedMessage"></param>
        private void AddToParagraph(string[] splittedMessage)
        {
            Image img;

            foreach (var element in splittedMessage)
            {
                if (_emoteDictionary.ContainsKey(element))
                {
                    img = createImage(_emoteDictionary[element]);
                    _messageParagraph.Inlines.Add(img);
                }
                else
                    _messageParagraph.Inlines.Add(new Bold(new Run(element)));
            }
        }

        /// <summary>
        /// Creates Image object loading proper emoticon icon
        /// </summary>
        /// <param name="uri">Path to the emoticons directory</param>
        /// <returns>Emoticon image</returns>
        private Image createImage(string uri)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Environment.CurrentDirectory + @"\Resources\img\" + uri);
            bitmap.EndInit();

            Image img = new Image();
            img.Source = bitmap;
            img.Height = 18;
            img.Width = 18;

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
        private void ChooseEmot_Click(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = _toOpen;
            _toOpen = !_toOpen;
        }

        private void Emote_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += ((ContentControl)sender).Content.ToString();
            Popup1.IsOpen = false;
        }
    }
}
