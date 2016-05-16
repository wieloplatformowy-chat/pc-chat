using System;
using System.Net.Mail;
using System.Windows;
using Czat.RestApiService;
using Czat.RestApiService.Services;

namespace Czat.Views
{
    /// <summary>
    /// Interaction logic for Rejestracja.xaml
    /// </summary>
    public partial class Rejestracja : Window
    {
        public UserRestService UserService { get; }

        public Rejestracja(UserRestService userService)
        {
            UserService = userService;
            InitializeComponent();
        }

        private void LoginOn_Click(object sender, RoutedEventArgs e) //obsluga guzika do logowania
        {
            Logowanie log = IoC.Resolve<Logowanie>();
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
                Logowanie log = IoC.Resolve<Logowanie>();
                log.Show();
                this.Close();
            }
        }
    }
}