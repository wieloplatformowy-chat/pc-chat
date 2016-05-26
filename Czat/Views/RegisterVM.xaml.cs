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

        public RegisterVM(UserRestService userService)
        {
            UserService = userService;
            InitializeComponent();
        }

        private void LoginOn_Click(object sender, RoutedEventArgs e) //obsluga guzika do logowania
        {
            LoginVM log = IoC.Resolve<LoginVM>();
            log.Show();
            this.Close();
        }

        private async void Rejestracja_Click(object sender, RoutedEventArgs e) //rejestracja guzik
        {
            bool IsEmailIsValid = false;
            try
            {
                MailAddress UserMailAdress = new MailAddress(Email.Text); //sprawdzanie poprawnosci emaila
                IsEmailIsValid = true;
            }
            catch (FormatException)
            {
                IsEmailIsValid = false;
            }

            if (Login.Text.Length <= 32 && Pass.Text.Length <= 32 && IsEmailIsValid == true && Pass.Text == PassRep.Text)
                //prosta walidacja oraz przejscie miedzy oknami
            {
                try
                {
                    await UserService.Register(Email.Text, Login.Text, Pass.Text);
                }
                catch (ApiException apiException)
                {
                    MessageBox.Show(apiException.Message, "Wystąpił błąd");
                    return;
                }

                MessageBox.Show("Zarejestrowano!");
                LoginVM log = IoC.Resolve<LoginVM>();
                log.Show();
                this.Close();
            }
        }
    }
}