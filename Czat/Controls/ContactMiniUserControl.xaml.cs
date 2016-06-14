using Czat.Views;
using RestApiService.Model;
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
    /// Interaction logic for ContactMiniUserControl.xaml
    /// </summary>
    public partial class ContactMiniUserControl : UserControl
    {
        public ContactListContactData ContactData { get; set; }
        public bool IsAdded { get { return isAdded; } }

        private BitmapImage avatar;
        private bool isAdded;

        public ContactMiniUserControl(ContactListContactData contact)
        {
            InitializeComponent();
            ContactData = contact;
            this.DataContext = ContactData;
            isAdded = false;
            string hash = GravatarHelper.HashEmailForGravatar(ContactData.Email);
            avatar = GravatarHelper.GetGravatarImage(string.Format("http://www.gravatar.com/avatar/{0}?size=80", hash));
            SetAvatar();
        }

        private void SetAvatar()
        {
            string hash = GravatarHelper.HashEmailForGravatar(ContactData.Email);
            Avatar.ImageSource = avatar;
        }

        private void AddRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            isAdded = !isAdded;
        }
    }
}
