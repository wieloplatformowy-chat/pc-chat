using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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

        public MainWindow()
        {
            InitializeComponent();
            document = new FlowDocument();
            MsgView.Document = document;
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <param name="message">contents of message</param>
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
        /// 
        /// </summary>
        /// <param name="splittedMessage"></param>
        private void AddToParagraph(string[] splittedMessage)
        {
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(Environment.CurrentDirectory + @"\emot 1.png");
            b.EndInit();

            Image img = new Image();
            img.Source = b;
            img.Height = 20;
            img.Width = 20;

            foreach (var element in splittedMessage)
            {
                if (element == ":)")
                    messageParagraph.Inlines.Add(img);
                else
                    messageParagraph.Inlines.Add(new Bold(new Run(element)));
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string[] SplitMessage(string message)
        {
            string pattern = @"(:\)) | (;\)) | (:\D) | (:\/) | (:\() | (<3) | (:P)";
            string[] partsOfMessage = System.Text.RegularExpressions.Regex.Split(message, pattern, System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace);

            return partsOfMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void emot1_Click(object sender, RoutedEventArgs e)
        {
            TextOfMsg.Text += emot1.Content.ToString();
        }
    }
}
