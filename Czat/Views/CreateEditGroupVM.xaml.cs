using Czat.Helpers;
using RestApiService;
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
using System.Windows.Shapes;

namespace Czat.Views
{
    /// <summary>
    /// Interaction logic for CreateGroupVM.xaml
    /// </summary>
    public partial class CreateEditGroupVM : Window
    {
        public GroupRestService GroupService { get; }
        public List<ContactListContactData> Contacts { get; }

        private List<ContactMiniUserControl> contactsControlls;
        private long? groupId;
        private ContactList contactListReference;
        private ContactListContactData groupData;

        public CreateEditGroupVM(List<ContactListContactData> contacts, ContactList contactList)
        {
            InitializeComponent();
            Title = "Stwórz nową grupę";
            GroupService = IoC.Resolve<GroupRestService>();
            Contacts = contacts;
            contactsControlls = new List<ContactMiniUserControl>();
            contactListReference = contactList;
            PutFriendsToInvite();          
            CreateButton.Click += CreateButton_Click;
        }

        public CreateEditGroupVM(List<ContactListContactData> contacts, ContactList contactList, ContactListContactData group)
        {
            InitializeComponent();
            Title = "Edytuj grupę";
            GroupService = IoC.Resolve<GroupRestService>();
            Contacts = contacts;
            contactsControlls = new List<ContactMiniUserControl>();
            contactListReference = contactList;
            groupData = group;
            PutFriendsToAdd();
            CreateButton.Click += EditButton_Click;
        }

        private void PutFriendsToInvite()
        {
            for (int i = 0; i < Contacts.Count; i++)
            {
                ContactMiniUserControl contactControl = new ContactMiniUserControl(Contacts[i]);
                contactsControlls.Add(contactControl);
                ListContainer.Children.Add(contactControl);
            }
        }

        private void PutFriendsToAdd()
        {
            for (int i = Contacts.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < groupData.Users.Count; j++)
                {
                    if (groupData.Users[j].Id == Contacts[i].Id)
                    {
                        Contacts.Remove(Contacts[i]);
                        break;
                    }
                }
            }
            for (int i = 0; i < Contacts.Count; i++)
            {
                ContactMiniUserControl contactControl = new ContactMiniUserControl(Contacts[i]);
                contactsControlls.Add(contactControl);
                ListContainer.Children.Add(contactControl);
            }
        }
        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(GroupNameInput.Text) && (GroupNameInput.Text != groupData.Name))
                {
                    await GroupService.ChangeConversationName(groupData.Id, GroupNameInput.Text); 
                    ContactList.Instance.UpdateGroupName(groupData, GroupNameInput.Text);
                }

                CreateButton.IsEnabled = false;

                var addedUsers = new List<long?>();
                var addedUsersDTO = new List<UserDTO>();
                foreach (ContactMiniUserControl listedUser in contactsControlls) {
                    if (!listedUser.IsAdded)
                        continue;

                    addedUsers.Add(listedUser.ContactData.Id);
                    addedUsersDTO.Add(new UserDTO {
                        Email = listedUser.ContactData.Email,
                        Id = listedUser.ContactData.Id,
                        Name = listedUser.ContactData.Name
                    });
                    if (addedUsers.Count > 0)
                        await GroupService.InviteUserToGroup(groupData.Id, addedUsers);
                }
                GetWindow(this)?.Close();
        }
            catch (ApiException apiException)
            {
                CreateButton.IsEnabled = true;
                // Get rid of MessageBox
                MessageBox.Show(apiException.Message, "Wystąpił błąd");
            }
}
        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(GroupNameInput.Text)) return;

                CreateButton.IsEnabled = false;
                var response = await GroupService.CreateNewGroup();
                groupId = response.Id;

                var addedUsers = new List<long?>();
                var addedUsersDTO = new List<UserDTO>();
                foreach (ContactMiniUserControl listedUser in contactsControlls)
                {
                    if (!listedUser.IsAdded)
                        continue;

                    addedUsers.Add(listedUser.ContactData.Id);
                    addedUsersDTO.Add(new UserDTO
                    {
                        Email = listedUser.ContactData.Email,
                        Id = listedUser.ContactData.Id,
                        Name = listedUser.ContactData.Name
                    });
                }
                await GroupService.InviteUserToGroup(groupId, addedUsers);
                await GroupService.ChangeConversationName(groupId, GroupNameInput.Text);
                contactListReference.AddNewGroup(new ContactListContactData { Id = groupId, Name = GroupNameInput.Text, IsOnline = true, IsPerson = false, Email = null, Users = addedUsersDTO });
                GetWindow(this)?.Close();
            }
            catch (ApiException apiException)
            {
                CreateButton.IsEnabled = true;
                // Get rid of MessageBox
                MessageBox.Show(apiException.Message, "Wystąpił błąd");
            }
        }

    }
}
