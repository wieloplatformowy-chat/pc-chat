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
        public GroupRestService GroupService { get; }

        public IList<UserDTO> FriendList;
        private IList<UserDTO> tempFriendList;
        private IList<GroupDTO> groupList;
        private List<ContactListContactData> contacts;
        private List<ContactUserControl> contactsControlls;
        private List<ContactListContactData> groups;
        private List<ContactUserControl> groupsControlls;
        private ContactListContactData currentUser;
        private Timer timer;

        public ContactList()
        {
            UserService = IoC.Resolve<UserRestService>();
            ContactListService = IoC.Resolve<ContactListRestService>();
            MessageService = IoC.Resolve<MessageRestService>();
            GroupService = IoC.Resolve<GroupRestService>();

            contacts = new List<ContactListContactData>();
            groups = new List<ContactListContactData>();
            contactsControlls = new List<ContactUserControl>();
            groupsControlls = new List<ContactUserControl>();
            InitializeComponent();
            FilContactListData();
            SetTimer();
        }

        private void SetTimer()
        {
            timer = new Timer(5000);
            timer.Elapsed += new ElapsedEventHandler(AskServerForUpdate);
            timer.Enabled = true;
        }

        private async void AskServerForUpdate(object sender, ElapsedEventArgs e)
        {
            IList<long?> unreadMessagesSenders = await MessageService.GeUnreadMessages();

            //sprawdzenie czy sa nowi znajomi i odfiltrowanie ich z listy
            tempFriendList = await ContactListService.GetFriendList();
            if (tempFriendList.Count > FriendList.Count)
            {
                List<UserDTO> newFriends = new List<UserDTO>();
                for (int i = tempFriendList.Count - 1; i >= 0; i--)
                {
                    for (int j = 0; j < FriendList.Count; j++)
                    {
                        if (tempFriendList[i].Id == FriendList[j].Id)
                        {
                            tempFriendList.RemoveAt(i);
                            break;
                        }
                    }
                }
                this.Dispatcher.Invoke((Action)(() =>
                {
                    //dodanie ludzi, ktorzy dodali nas do znajomych
                    for (int i = 0; i < tempFriendList.Count; i++)
                    {
                        ContactListContactData contact = new ContactListContactData { Id = tempFriendList[i].Id, Name = tempFriendList[i].Name, IsOnline = true, IsPerson = true, Email = tempFriendList[i].Email, Users = null };
                        ContactUserControl contactControl = new ContactUserControl(contact, currentUser);
                        FriendList.Add(tempFriendList[i]);
                        contactControl.SetUnreadMessageIcon(unreadMessagesSenders);
                        contactsControlls.Add(contactControl);
                        contacts.Add(contact);
                        ListContainer.Children.Insert(contacts.Count, contactControl);
                    }
                }));
            }

            //aktualizacja nieodczytanych wiadomosci
            for (int i = 0; i < contacts.Count; i++)
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    contactsControlls[i].SetUnreadMessageIcon(unreadMessagesSenders);
                }));
            }

            for (int i = 0; i < contactsControlls.Count; i++)
            {
                OnlineResponse onlineResponse = await ContactListService.IsUserOnline(contactsControlls[i].ContactData.Id);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    contactsControlls[i].UpdateAvatar(onlineResponse.Online);
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

            IList<long?> unreadMessagesSenders = await MessageService.GeUnreadMessages();

            FriendList = await ContactListService.GetFriendList();
            for (int i = 0; i < FriendList.Count; i++)
            {
                OnlineResponse onlineResponse = await ContactListService.IsUserOnline(FriendList[i].Id);
                ContactListContactData contact = new ContactListContactData { Id = FriendList[i].Id, Name = FriendList[i].Name, IsOnline = onlineResponse.Online, IsPerson = true, Email = FriendList[i].Email, Users = null };
                ContactUserControl contactControl = new ContactUserControl(contact, currentUser);
                contactControl.SetUnreadMessageIcon(unreadMessagesSenders);
                contactsControlls.Add(contactControl);
                contacts.Add(contact);
                ListContainer.Children.Add(contactControl);
            }

            HeaderUserControl groupsHeader = new HeaderUserControl(new ContactListHeaderData { Title = "Grupy" });
            ListContainer.Children.Add(groupsHeader);

            groupList = await GroupService.GetGroups();
            for (int i = 0; i < groupList.Count; i++)
            {
                ContactListContactData contact = new ContactListContactData { Id = groupList[i].Id, Name = groupList[i].Name, IsOnline = true, IsPerson = false, Email = null, Users = groupList[i].Users };
                ContactUserControl groupControl = new ContactUserControl(contact, currentUser);
                groupControl.SetUnreadMessageIcon(unreadMessagesSenders);
                groupsControlls.Add(groupControl);
                groups.Add(contact);
                ListContainer.Children.Add(groupControl);
            }
        }

        private void AddNewFriendButton_Click(object sender, RoutedEventArgs e)
        { 
            new FriendSearch(this).Show();
        }

        private void CreateNewGroupButton_Click(object sender, RoutedEventArgs e)
        {
            new CreateGroupVM(contacts, this).Show();
        }

        public void AddNewContact(ContactListContactData contact)
        {
            contacts.Add(contact);
            ContactUserControl contactControl = new ContactUserControl(contact, currentUser);
            contactsControlls.Add(contactControl);
            ListContainer.Children.Insert(contacts.Count, contactControl);
        }

        public void AddNewGroup(ContactListContactData contact)
        {
            groups.Add(contact);
            ContactUserControl contactControl = new ContactUserControl(contact, currentUser);
            contactsControlls.Add(contactControl);
            ListContainer.Children.Add(contactControl);
        }

        public void RemoveContact(ContactListContactData contact)
        {
            contacts.Remove(contact);
            for (int i = 0; i < FriendList.Count; i++)
            {
                if (contact.Id == FriendList[i].Id)
                    FriendList.Remove(FriendList[i]);
            }
        }
    }
}
