using System.Windows;
using Czat.RestApiService;
using Czat.RestApiService.Services;

namespace Czat.Views
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

        private async void LoginOn_Click(object sender, RoutedEventArgs e)    //obsluga guzika loguj
        {
            try
            {
                await UserService.Login(Login.Text, Password.Text);
            }
            catch (ApiException apiException)
            {
                MessageBox.Show(apiException.Message, "Wystąpił błąd");
                return;
            }

            MainWindow mainWindow = IoC.Resolve<MainWindow>();
            mainWindow.Show();
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)   //obsluga guzika rejestracja
        {
            Rejestracja Register = IoC.Resolve<Rejestracja>();
            Register.Show();
            this.Close();
        }
    }
}
