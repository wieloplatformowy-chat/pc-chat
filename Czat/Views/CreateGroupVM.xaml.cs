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
    public partial class CreateGroupVM : Window
    {
        public GroupRestService GroupService { get; }
        public List<ContactListContactData> Contacts { get; }

        private List<ContactMiniUserControl> contactsControlls;
        private long? groupId;
        private ContactList contactListReference;

        public CreateGroupVM(List<ContactListContactData> contacts, ContactList contactList)
        {
            InitializeComponent();
            GroupService = IoC.Resolve<GroupRestService>();
            Contacts = contacts;
            contactsControlls = new List<ContactMiniUserControl>();
            contactListReference = contactList;
            PutFriendsToInvite();
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
        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(GroupNameInput.Text))
                {
                    CreateButton.IsEnabled = false;
                    groupId = await GroupService.CreateNewGroup();
                    List<long?> addedUsers = new List<long?>();
                    List<UserDTO> addedUsersDTO = new List<UserDTO>();
                    for (int i = 0; i < contactsControlls.Count; i++)
                    {
                        if (contactsControlls[i].IsAdded)
                        {
                            addedUsers.Add(contactsControlls[i].ContactData.Id);
                            addedUsersDTO.Add(new UserDTO() { Email = contactsControlls[i].ContactData.Email, Id = contactsControlls[i].ContactData.Id, Name = contactsControlls[i].ContactData.Name });
                        }
                    }
                    await GroupService.InviteUserToGroup(groupId, addedUsers);
                    contactListReference.AddNewGroup(new ContactListContactData() { Id = groupId, Name = GroupNameInput.Text, IsOnline = true, IsPerson = false, Email = null, Users = addedUsersDTO });
                Window.GetWindow(this).Close();
                }
            }
            catch (ApiException apiException)
            {
                CreateButton.IsEnabled = true;
                // Get rid of MessageBox
                MessageBox.Show(apiException.Message, "Wystąpił błąd");
                return;
            }
        }
    }
}
