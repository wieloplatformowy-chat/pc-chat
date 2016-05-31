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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SendMsg.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        FlowDocument doc = new FlowDocument();

        private void SendMsg_Click(object sender, RoutedEventArgs e)
        {
            if ((TextOfMsg.Text != null) && (TextOfMsg.Text.ToString() != ""))
            {
                DateTime DateNow = DateTime.Now;
                
                Paragraph para1 = new Paragraph();
                Paragraph para2 = new Paragraph();

                para1.Inlines.Add(new Bold(new Run(TextOfMsg.Text)));
                para1.FontSize = 12;
                para1.Background = System.Windows.Media.Brushes.DarkCyan;
                para1.Foreground = System.Windows.Media.Brushes.White;
                doc.Blocks.Add(para1);

                para2.Inlines.Add(new Run(DateNow.ToString("HH:mm")));
                para2.FontSize = 8;
                doc.Blocks.Add(para2);

                MsgView.Document = doc;

                TextOfMsg.Text = null;
            }
        }
    }
}
