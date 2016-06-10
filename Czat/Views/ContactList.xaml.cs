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
using System.Windows.Data;
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

        private ContactListElementData currentUser;
        public ContactListElementData CurrentUser { get { return currentUser; } }

        private IList<UserDTO> friendList;
        public ContactList(UserRestService userService, ContactListRestService contactListService)
        {
            UserService = userService;
            ContactListService = contactListService;
            InitializeComponent();
            FilContactListData();
        }
     
        private async void FilContactListData()
        {
            UserDTO currentUserDTO = await UserService.WhoAmI();
            currentUser = new ContactListElementData(currentUserDTO.Id, currentUserDTO.Name, true, true, null);
            CurrentUserName.Text = currentUser.Name;
        }

        private void AddNewFriendButton_Click(object sender, RoutedEventArgs e)
        { 
            IoC.Resolve<FriendSearch>().Show();
        }


    }
}
