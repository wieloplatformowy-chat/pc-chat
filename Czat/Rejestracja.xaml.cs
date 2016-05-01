using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Czat
{
    /// <summary>
    /// Interaction logic for Rejestracja.xaml
    /// </summary>
    public partial class Rejestracja : Window
    {
        public Rejestracja()
        {
            InitializeComponent();
        }

        private void LoginOn_Click(object sender, RoutedEventArgs e)
        {
            logowanie log = new logowanie();
            log.Show();
            this.Close();
        }

        private void Rejestracja_Click(object sender, RoutedEventArgs e)
        {
            logowanie log = new logowanie();
            log.Show();
            this.Close();
        }
    }
}
