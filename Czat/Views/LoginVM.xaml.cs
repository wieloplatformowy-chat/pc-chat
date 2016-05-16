using System.Windows;
using System.Windows.Input;
using Czat.RestApiService;
using Czat.RestApiService.Services;

namespace Czat.Views
{
    /// <summary>
    /// Interaction logic for logowanie.xaml
    /// </summary>
    public partial class LoginVM : Window
    {
        public UserRestService UserService { get; }

        public LoginVM(UserRestService userService)
        {
            UserService = userService;
            InitializeComponent();
        }

        private async void LoginOn_Click(object sender, RoutedEventArgs e) //obsluga guzika loguj
        {
            try
            {
                await UserService.Login(Login.Text, Password.Password);
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

        private void Register_Click(object sender, RoutedEventArgs e) //obsluga guzika rejestracja
        {
            RegisterVM registerVm = IoC.Resolve<RegisterVM>();
            registerVm.Show();
            this.Close();
        }

        private void LoginVM_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.MainWindow.DragMove();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}