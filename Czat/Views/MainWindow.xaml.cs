using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Czat.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        private const double MergeInterval = 30;

        private FlowDocument document;
        private DateTime currentTime;
        private DateTime previousTime;
        private TimeSpan timeRange;
        private Paragraph messageParagraph;
        private Paragraph dateTimeParagraph;

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendMsg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextOfMsg.Text))
                return;

            AddMessage(TextOfMsg.Text);
            TextOfMsg.Text = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isNewNeeded"></param>
        /// <returns></returns>
        private Paragraph GetMessageParagraph(bool isNewNeeded = false)
        {
            if (messageParagraph != null && !isNewNeeded)
                return messageParagraph;

            messageParagraph = new Paragraph();
            messageParagraph.FontSize = 12;
            messageParagraph.Background = System.Windows.Media.Brushes.DarkCyan;
            messageParagraph.Foreground = System.Windows.Media.Brushes.White;

            return messageParagraph;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isNewNeeded"></param>
        /// <returns></returns>
        private Paragraph GetDateTimeParagraph(bool isNewNeeded = false)
        {
            if (dateTimeParagraph != null && !isNewNeeded)
                return dateTimeParagraph;

            dateTimeParagraph = new Paragraph();
            dateTimeParagraph.FontSize = 8;

            return dateTimeParagraph;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void AddMessage(string message)
        {
            currentTime = DateTime.Now;

            // Check if new or merged message
            // TODO sprawdź czy sender jest ten sam
            bool isNewMessage = true;
            timeRange = currentTime - previousTime;
            if (timeRange.TotalSeconds <= MergeInterval)
                isNewMessage = false;

            var msgParagraph = GetMessageParagraph(isNewMessage);
            var dateParagraph = GetDateTimeParagraph(isNewMessage);

            if (isNewMessage)
            {
                document.Blocks.Add(messageParagraph);
                document.Blocks.Add(dateTimeParagraph);
                dateTimeParagraph.Inlines.Add(new Run(currentTime.ToString("HH:mm")));
            }
            else
                message = "\n" + message;

            messageParagraph.Inlines.Add(new Bold(new Run(message)));

            previousTime = currentTime;
        }
    }
}
