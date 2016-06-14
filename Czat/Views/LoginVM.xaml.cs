using System.Windows;
using System.Windows.Input;
using RestApiService;
using RestApiService.Services;

namespace Czat.Views
{
    /// <summary>
    /// Interaction logic for LoginVM.xaml
    /// </summary>
    public partial class LoginVM : Window
    {
        public UserRestService UserService { get; }

        public LoginVM()
        {
            UserService = IoC.Resolve<UserRestService>();
            InitializeComponent();
        }

        /// <summary>
        /// Tries to login entered user on click event
        /// </summary>
        private async void LoginOn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginButton.IsEnabled = false;
                await UserService.Login(Login.Text, Password.Password);
            }
            catch (ApiException apiException)
            {
                LoginButton.IsEnabled = true;
                // Get rid of MessageBox
                MessageBox.Show(apiException.Message, "Wystąpił błąd");
                return;
            }

            new ContactList().Show();
            Close();
        }

        /// <summary>
        /// Switches to registration window
        /// </summary>
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            new RegisterVM().Show();
            Close();
        }

        /// <summary>
        /// Adds drag functionality to window
        /// </summary>
        private void LoginVM_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.MainWindow.DragMove();
        }
    }
}