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
    /// Interaction logic for logowanie.xaml
    /// </summary>
    public partial class logowanie : Window
    {
        public logowanie()
        {
            InitializeComponent();
        }

        private void LoginOn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Rejestracja rej = new Rejestracja();
            rej.Show();
            this.Close();
        }
    }
}
