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
        public ContactListContactData CurrentUser { get; set; }
        public ContactListRestService ContactListService { get; }
        public bool IsConversationWindowVisible { get; set; }

        private Window conversationWindow;
        public ContactUserControl(ContactListContactData contactData, ContactListContactData me, ContactListRestService contactRestService)
        {
            InitializeComponent();
            ContactListService = contactRestService;
            ContactData = contactData;
            CurrentUser = me;
            this.DataContext = ContactData;
            string hash = GravatarHelper.HashEmailForGravatar(contactData.Email);
            Avatar.ImageSource = GravatarHelper.GetGravatarImage(string.Format("http://www.gravatar.com/avatar/{0}?size=80", hash));
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

        private void MainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsConversationWindowVisible || !conversationWindow.IsVisible)
            {
                IsConversationWindowVisible = true;
                conversationWindow = new MainWindow(CurrentUser.ID, ContactData.ID);
                conversationWindow.Show();
            }
            else
            {
                conversationWindow.Activate();              
            }
        }
    }
}
