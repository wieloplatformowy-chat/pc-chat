using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

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

        private FlowDocument document;
        private DateTime currentTime;
        private DateTime previousTime;
        private TimeSpan timeRange;
        private Paragraph messageParagraph;
        private Paragraph dateTimeParagraph;
        private bool toOpen = true;
        private RestApiService.Model.UserDTO me = new RestApiService.Model.UserDTO();
        private RestApiService.Model.UserDTO currentSender = new RestApiService.Model.UserDTO();
        private RestApiService.Model.UserDTO previousSender = new RestApiService.Model.UserDTO();
        private Dictionary<string, string> emotDictionary;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDictionary();
            document = new FlowDocument();
            MsgView.Document = document;
            System.IO.Directory.SetCurrentDirectory(@"..\..\");
        }

        private void InitializeDictionary()
        {
            emotDictionary = new Dictionary<string, string>();
            emotDictionary.Add(":)", "emot 1.png");
            emotDictionary.Add(";)", "emot 2.png");
            emotDictionary.Add(":D", "emot 3.png");
            emotDictionary.Add(":|", "emot 4.png");
            emotDictionary.Add(":/", "emot 5.png");
            emotDictionary.Add(":(", "emot 6.png");
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SendMsg.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
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

            AddMessage(TextOfMsg.Text, me.Id);
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
            if (messageParagraph != null && !isNewNeeded)
                return messageParagraph;

            messageParagraph = new Paragraph();
            messageParagraph.FontSize = 12;

            if (senderId == me.Id)
            {
                messageParagraph.Background = System.Windows.Media.Brushes.DarkCyan;
                messageParagraph.Foreground = System.Windows.Media.Brushes.White;
                messageParagraph.TextAlignment = TextAlignment.Right;
            }
            else
            {
                messageParagraph.Background = System.Windows.Media.Brushes.LightGray;
                messageParagraph.TextAlignment = TextAlignment.Left;
            }

            return messageParagraph;
        }

        /// <summary>
        /// Gets date time paragraph
        /// </summary>
        /// <param name="isNewNeeded">Checks if new paragraph is needed</param>
        /// <param name="senderId">Id of current message sender</param>
        /// <returns>Paragraph</returns>
        private Paragraph GetDateTimeParagraph(bool isNewNeeded, long? senderId)
        {
            if (dateTimeParagraph != null && !isNewNeeded)
                return dateTimeParagraph;

            dateTimeParagraph = new Paragraph();
            dateTimeParagraph.FontSize = 8;

            if (senderId == me.Id)
                dateTimeParagraph.TextAlignment = TextAlignment.Right;
            else
                dateTimeParagraph.TextAlignment = TextAlignment.Left;

            return dateTimeParagraph;
        }

        /// <summary>
        /// Adds new message
        /// </summary>
        /// <param name="message">Contents of message</param>
        /// <param name="senderId">Id of current message sender</param>
        private void AddMessage(string message, long? senderId)
        {
            currentTime = DateTime.Now;
            currentSender.Id = senderId;

            bool areTheSameSenders = false;
            bool isNewMessage = true;

            if (currentSender.Id == previousSender.Id)
                areTheSameSenders = true;

            timeRange = currentTime - previousTime;

            // Checks if new or merged message
            if (timeRange.TotalSeconds <= MergeInterval && areTheSameSenders) 
                isNewMessage = false;

            GetMessageParagraph(isNewMessage, currentSender.Id);
            GetDateTimeParagraph(isNewMessage, currentSender.Id);

            if (isNewMessage)
            {
                document.Blocks.Add(messageParagraph);
                document.Blocks.Add(dateTimeParagraph);
                dateTimeParagraph.Inlines.Add(new Run(currentTime.ToString("HH:mm")));
            }
            else
                message = "\n" + message;

            string[] splittedMessage = SplitMessage(message);
            AddToParagraph(splittedMessage);

            previousTime = currentTime;
            previousSender = currentSender;
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
                if (emotDictionary.ContainsKey(element))
                {
                    img = createImage(emotDictionary[element]);
                    messageParagraph.Inlines.Add(img);
                }
                else
                    messageParagraph.Inlines.Add(new Bold(new Run(element)));
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
            string pattern = @"(:\)) | (;\)) | (:\D) | (:\/) | (:\() | (:\|)";
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
            Popup1.IsOpen = toOpen;
            toOpen = !toOpen;
        }

        private void emot1_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += emot1.Content.ToString();
            Popup1.IsOpen = false;
        }

        private void emot2_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += emot2.Content.ToString();
            Popup1.IsOpen = false;
        }

        private void emot3_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += emot3.Content.ToString();
            Popup1.IsOpen = false;
        }

        private void emot4_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += emot4.Content.ToString();
            Popup1.IsOpen = false;
        }

        private void emot5_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += emot5.Content.ToString();
            Popup1.IsOpen = false;
        }

        private void emot6_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += emot6.Content.ToString();
            Popup1.IsOpen = false;
        }
    }
}
