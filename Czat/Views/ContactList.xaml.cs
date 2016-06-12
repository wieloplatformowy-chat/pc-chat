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
using System.Timers;
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
        public MessageRestService MessageService { get; }
        public ContactListContactData CurrentUser { get { return currentUser; } }

        private IList<UserDTO> friendList;
        private List<ContactListContactData> contacts;
        private List<ContactUserControl> contactsControlls;
        private ContactListContactData currentUser;
        private Timer timer;

        public ContactList()
        {
            UserService = IoC.Resolve<UserRestService>();
            ContactListService = IoC.Resolve<ContactListRestService>();
            MessageService = IoC.Resolve<MessageRestService>();
            contacts = new List<ContactListContactData>();
            contactsControlls = new List<ContactUserControl>();
            InitializeComponent();
            FilContactListData();
            SetTimer();
        }

        private void SetTimer()
        {
            timer = new Timer(5000);
            timer.Elapsed += new ElapsedEventHandler(AskServerForChanges);
            timer.Enabled = true;
        }

        private async void AskServerForChanges(object sender, ElapsedEventArgs e)
        {
            for (int i = 0; i < contactsControlls.Count; i++)
            {
                OnlineResponse onlineResponse = await ContactListService.IsUserOnline(contactsControlls[i].ContactData.Id);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    contactsControlls[i].UpdateAvatar(onlineResponse.Online);
                }));
            }

            IList<long?> unreadMessagesSenders = await MessageService.GeUnreadMessages();

            for (int i = 0; i < contactsControlls.Count; i++)
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    contactsControlls[i].SetUnreadMessageIcon(unreadMessagesSenders);
                }));
            }
        }

        private async void FilContactListData()
        {
            UserDTO currentUserDTO = await UserService.WhoAmI();
            currentUser = new ContactListContactData { Id = currentUserDTO.Id, Name = currentUserDTO.Name, IsOnline = true, IsPerson = true, Email = currentUserDTO.Email };
            CurrentUserName.Text = currentUser.Name;
            string hash = GravatarHelper.HashEmailForGravatar(currentUser.Email);
            Avatar.ImageSource = GravatarHelper.GetGravatarImage(string.Format("http://www.gravatar.com/avatar/{0}?size=80", hash));

            HeaderUserControl contactsHeader = new HeaderUserControl(new ContactListHeaderData { Title = "Kontakty" });
            ListContainer.Children.Add(contactsHeader);
            friendList = await ContactListService.GetFriendList();
            IList<long?> unreadMessagesSenders = await MessageService.GeUnreadMessages();
            for (int i = 0; i < friendList.Count; i++)
            {
                OnlineResponse onlineResponse = await ContactListService.IsUserOnline(friendList[i].Id);
                ContactListContactData contact = new ContactListContactData { Id = friendList[i].Id, Name = friendList[i].Name, IsOnline = onlineResponse.Online, IsPerson = true, Email = currentUserDTO.Email };
                ContactUserControl contactControl = new ContactUserControl(contact, currentUser);
                contactControl.SetUnreadMessageIcon(unreadMessagesSenders);
                contactsControlls.Add(contactControl);
                contacts.Add(contact);
                ListContainer.Children.Add(contactControl);
            }
            HeaderUserControl groupsHeader = new HeaderUserControl(new ContactListHeaderData { Title = "Grupy" });
            ListContainer.Children.Add(groupsHeader);
        }

        private void AddNewFriendButton_Click(object sender, RoutedEventArgs e)
        { 
            new FriendSearch(this).Show();
        }

        public void AddNewContact(ContactListContactData contact)
        {
            contacts.Add(contact);
            ContactUserControl contactControl = new ContactUserControl(contact, currentUser);
            ListContainer.Children.Insert(contacts.Count, contactControl);
        }

        public void RemoveContact(ContactListContactData contact)
        {
            contacts.Remove(contact);
        }
    }
}
