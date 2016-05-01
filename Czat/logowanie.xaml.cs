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
    public partial class Logowanie : Window
    {
        public Logowanie()
        {
            InitializeComponent();
        }

        private void LoginOn_Click(object sender, RoutedEventArgs e)    //obsluga guzika loguj
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)   //obsluga guzika rejestracja
        {
            Rejestracja Register = new Rejestracja();
            Register.Show();
            this.Close();
        }

        

        private void Login_PreviewKeyDown(object sender, KeyEventArgs e)    //wykrywanie wpisywania w polu login
        {
            if (Login.Text == "Login")
            {
                Login.Text = "";
            }
        }

        private void Password_PreviewKeyDown(object sender, KeyEventArgs e) //wykrywanie wpisywania w polu haslo
        {
            if (Password.Text == "Hasło")
            {
                Password.Text = "";
            }
        }     

        
    }
}
