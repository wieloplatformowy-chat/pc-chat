using Czat.Views;
using RestApiService.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Czat.Helpers
{
    /// <summary>
    /// Interaction logic for ContactUserControl.xaml
    /// </summary>
    public partial class ContactUserControl : UserControl
    {
        public ContactListContactData ContactData { get; set; }
        public ContactListRestService ContactListService { get; }
        public ContactUserControl(ContactListContactData contactData, ContactListRestService contactRestService)
        {
            InitializeComponent();
            ContactListService = contactRestService;
            ContactData = contactData;
            this.DataContext = ContactData;
        }

        private async void RemoveFriend_Click(object sender, RoutedEventArgs e)
        {
            await ContactListService.RemoveFriend(ContactData.ID);
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ContactList))
                {
                    (window as ContactList).RemoveContact(ContactData);
                    break;
                }
            }
            ((StackPanel)this.Parent).Children.Remove(this);
        }
    }
}
