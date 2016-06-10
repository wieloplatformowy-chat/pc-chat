﻿using RestApiService;
using RestApiService.Services;
using RestApiService.Model;
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
    /// Interaction logic for FriendSearch.xaml
    /// </summary>
    public partial class FriendSearch : Window
    {
        public UserRestService UserService { get; }
        public ContactListRestService ContactListService { get; }

        public FriendSearch(UserRestService userService, ContactListRestService contactListService)
        {
            UserService = userService;
            ContactListService = contactListService;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private async void FindButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FindButton.IsEnabled = false;
                IList<UserDTO> potentialFriendsList = await UserService.Search(new SearchUserParam { Email = null, Name = FriendName.Text });
                for (int i = 0; i < potentialFriendsList.Count; i++)
                {
                    if (potentialFriendsList[i].Name == FriendName.Text)
                    {
                        await ContactListService.AddFriend(potentialFriendsList[i].Id);
                        Window.GetWindow(this).Close();
                    }
                }
            }
            catch (ApiException apiException)
            {
                FindButton.IsEnabled = true;
                // Get rid of MessageBox
                MessageBox.Show(apiException.Message, "Wystąpił błąd");
                return;
            }
        }
    }
}
