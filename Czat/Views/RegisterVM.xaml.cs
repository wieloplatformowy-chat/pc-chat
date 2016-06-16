using System;
using System.Net.Mail;
using System.Windows;
using RestApiService;
using RestApiService.Services;

namespace Czat.Views
{
    /// <summary>
    /// Interaction logic for RegisterVM.xaml
    /// </summary>
    public partial class RegisterVM : Window
    {
        public UserRestService UserService { get; }

        public RegisterVM()
        {
            UserService = IoC.Resolve<UserRestService>();
            InitializeComponent();
        }

        /// <summary>
        /// Switches to login window
        /// </summary>
        private void LoginOn_Click(object sender, RoutedEventArgs e)
        {
            new LoginVM().Show();
            Close();
        }

        /// <summary>
        /// Tries to register entered user on click event
        /// </summary>
        private async void Rejestracja_Click(object sender, RoutedEventArgs e)
        {
            // Email validation
            bool isEmailValid = false;
            try
            {
                new MailAddress(EMail.Text);
                isEmailValid = true;
            }
            catch (Exception) {/* isEmailValid: false */}

            //TODO proper validation
            // Simple user data validation
            if (Login.Text.Length > 32 || Password.Password.Length > 32 || !isEmailValid || Password.Password != RepeatPassword.Password)
                return;

            // Registration
            try
            {
                RegisterButton.IsEnabled = false;
                await UserService.Register(EMail.Text, Login.Text, Password.Password);
            }
            catch (ApiException apiException)
            {
                //TODO Get rid of MessageBox
                MessageBox.Show(apiException.Message, "Wystąpił błąd");
                RegisterButton.IsEnabled = true;
                return;
            }
            //TODO Get rid of MessageBox
            MessageBox.Show("Zarejestrowano!");

            // Show login window
            new LoginVM().Show();
            Close();
        }
    }
}