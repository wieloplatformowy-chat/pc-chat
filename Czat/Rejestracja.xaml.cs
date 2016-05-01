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

        private void LoginOn_Click(object sender, RoutedEventArgs e)
        {
            logowanie log = new logowanie();
            log.Show();
            this.Close();
        }        

        private void Rejestracja_Click(object sender, RoutedEventArgs e)
        {
            bool czyOK = false;
            try
            {
                MailAddress MA = new MailAddress(Email.Text);
                czyOK = true;
            }
            catch (FormatException)
            {

                czyOK = false;
            }
            

            if (Login.Text.Length<=32 && Hasło.Text.Length<=32 && czyOK==true  &&Hasło.Text==HasłoRep.Text)
            {
                MessageBox.Show("Zarejestrowano!");
                logowanie log = new logowanie();
                log.Show();
                this.Close();
            }
            
        }       



        private void Hasło_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Hasło.Text == "Hasło")
            {
                Hasło.Text = "";
            }
        }

        private void Email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Email.Text == "E-Mail")
            {
                Email.Text = "";
            }
        }

        private void HasłoRep_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (HasłoRep.Text=="Powtórz Hasło")
            {
                HasłoRep.Text = "";
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
