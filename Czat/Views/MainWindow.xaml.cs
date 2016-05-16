using System;
using System.Windows;
using System.Windows.Controls;
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

        private void SendMsg_Click(object sender, RoutedEventArgs e)
        {
            if ((TextOfMsg.Text != null) && (TextOfMsg.Text.ToString() != ""))
            {
                DateTime DateNow = DateTime.Now;

                MsgView.Text += DateNow.ToString();

                MsgView.AppendText(Environment.NewLine);

                MsgView.Text += TextOfMsg.Text;

                MsgView.AppendText(Environment.NewLine);

                TextOfMsg.Text = null; 
            }

            
        }
    }
}
