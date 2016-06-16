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
using RestApiService;
using RestApiService.Services;

namespace Czat
{
    /// <summary>
    /// Interaction logic for logowanie.xaml
    /// </summary>
    public partial class Logowanie : Window
    {
        public UserRestService UserService { get; }
        public Logowanie(UserRestService userService)
        {
            UserService = userService;
            InitializeComponent();
        }

        private void LoginOn_Click(object sender, RoutedEventArgs e)    //obsluga guzika loguj
        {
            try
            {
                UserService.Login(Login.Text, Password.Text);
            }
            catch (ApiException apiException)
            {
                MessageBox.Show(apiException.Message, "Wystąpił błąd");
                return;
            }

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
    }
}
