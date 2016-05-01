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
using System.Net.Mail;


namespace Czat
{
    /// <summary>
    /// Interaction logic for Rejestracja.xaml
    /// </summary>
    public partial class Rejestracja : Window
    {
        public Rejestracja()
        {
            InitializeComponent();
        }

        private void LoginOn_Click(object sender, RoutedEventArgs e)    //obsluga guzika do logowania
        {
            Logowanie log = new Logowanie();
            log.Show();
            this.Close();
        }        

        private void Rejestracja_Click(object sender, RoutedEventArgs e) //rejestracja guzik
        {
            bool IsEmailIsValid = false;
            try
            {
                MailAddress UserMailAdress = new MailAddress(Email.Text);   //sprawdzanie poprawnosci emaila
                IsEmailIsValid = true;
            }
            catch (FormatException)
            {

                IsEmailIsValid = false;
            }
            

            if (Login.Text.Length<=32 && Pass.Text.Length<=32 && IsEmailIsValid==true  &&Pass.Text==PassRep.Text)    //prosta walidacja oraz przejscie miedzy oknami
            {
                MessageBox.Show("Zarejestrowano!");
                Logowanie log = new Logowanie();
                log.Show();
                this.Close();
            }
            
        }       



        private void Pass_PreviewKeyDown(object sender, KeyEventArgs e) //czyszczenie textboxow
        {
            if (Pass.Text == "Hasło")
            {
                Pass.Text = "";
            }
        }

        private void Email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Email.Text == "E-Mail")
            {
                Email.Text = "";
            }
        }

        private void PassRep_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (PassRep.Text=="Powtórz Hasło")
            {
                PassRep.Text = "";
            }
        }

        private void Login_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Login.Text == "Login")
            {
                Login.Text = "";
            }
        }

        
    }
}
