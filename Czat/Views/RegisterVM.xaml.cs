﻿using System;
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

        /// <summary>
        /// Switches to login window
        /// </summary>
        private void LoginOn_Click(object sender, RoutedEventArgs e)
        {
            IoC.Resolve<LoginVM>().Show();
            Close();
        }

        /// <summary>
        /// Tries to register entered user on click event
        /// </summary>
        private async void Rejestracja_Click(object sender, RoutedEventArgs e)
        {
            // Email validation
            bool isEmailValid = false;
            try {
                new MailAddress(Email.Text);
                isEmailValid = true;
            } catch (Exception) {/* isEmailValid: false */}

            //TODO proper validation
            // Simple user data validation
            if (Login.Text.Length > 32 || Pass.Text.Length > 32 || !isEmailValid || Pass.Text != PassRep.Text)
                return;

            // Registration
            try 
            {
                Register.IsEnabled = false;
                await UserService.Register(Email.Text, Login.Text, Pass.Text);
            }
            catch (ApiException apiException)
            {
                //TODO Get rid of MessageBox
                MessageBox.Show(apiException.Message, "Wystąpił błąd");
                Register.IsEnabled = true;
                return;
            }
            //TODO Get rid of MessageBox
            MessageBox.Show("Zarejestrowano!");

            // Show login window
            IoC.Resolve<LoginVM>().Show();
            Close();
        }
    }
}