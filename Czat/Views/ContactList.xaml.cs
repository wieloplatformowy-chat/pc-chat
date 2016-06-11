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
using RestApiService;
using RestApiService.Services;
using RestApiService.Model;
using Czat.Helpers;

namespace Czat.Views
{
    /// <summary>
    /// Interaction logic for ContactList.xaml
    /// </summary>
    public partial class ContactList : Window
    {
        public UserRestService UserService { get; }
        public ContactListRestService ContactListService { get; }

        private ContactListContactData currentUser;
        public ContactListContactData CurrentUser { get { return currentUser; } }

        private IList<UserDTO> friendList;
        private List<ContactListContactData> contacts;
        public ContactList(UserRestService userService, ContactListRestService contactListService)
        {
            UserService = userService;
            ContactListService = contactListService;
            contacts = new List<ContactListContactData>();
            InitializeComponent();
            FilContactListData();
        }
     
        private async void FilContactListData()
        {
            UserDTO currentUserDTO = await UserService.WhoAmI();
            currentUser = new ContactListContactData { ID = currentUserDTO.Id, Name = currentUserDTO.Name, IsOnline = true, IsPerson = true, Avatar = null };
            CurrentUserName.Text = currentUser.Name;
            HeaderUserControl contactsHeader = new HeaderUserControl(new ContactListHeaderData { Title = "Kontakty" });
            ListContainer.Children.Add(contactsHeader);
            friendList = await ContactListService.GetFriendList();
            for (int i = 0; i < friendList.Count; i++)
            {
                ContactListContactData contact = new ContactListContactData { ID = friendList[i].Id, Name = friendList[i].Name, IsOnline = true, IsPerson = true, Avatar = null };
                ContactUserControl contactControl = new ContactUserControl(contact, ContactListService);
                contacts.Add(contact);
                ListContainer.Children.Add(contactControl);
            }
            HeaderUserControl groupsHeader = new HeaderUserControl(new ContactListHeaderData { Title = "Groupy" });
            ListContainer.Children.Add(groupsHeader);
        }

        private void AddNewFriendButton_Click(object sender, RoutedEventArgs e)
        { 
            IoC.Resolve<FriendSearch>().Show();
        }

        public void AddNewContact(ContactListContactData contact)
        {
            contacts.Add(contact);
            ContactUserControl contactControl = new ContactUserControl(contact, ContactListService);
            ListContainer.Children.Insert(contacts.Count, contactControl);
        }

        public void RemoveContact(ContactListContactData contact)
        {
            contacts.Remove(contact);
        }
    }
}
