using Czat.Views;
using RestApiService.Model;
using RestApiService.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Czat.Helpers
{
    /// <summary>
    /// Interaction logic for ContactUserControl.xaml
    /// </summary>
    public partial class ContactUserControl : UserControl
    {
        public ContactListContactData ContactData { get; set; }
        public ContactListRestService ContactListService { get; }
        public ConversationRestService ConversationService { get; }
        public MessageRestService MessageService { get; }
        public MainWindow ConversationWindow { get { return conversationWindow; } }
        public bool IsConversationWindowVisible { get; set; }
        private readonly string _soundDirectoryPath;

        private bool online;
        private BitmapImage avatar;
        private MainWindow conversationWindow;
        private ContactListContactData currentUser;

        public ContactUserControl(ContactListContactData contactData, ContactListContactData me)
        {
            InitializeComponent();
            ContactListService = IoC.Resolve<ContactListRestService>();
            ConversationService = IoC.Resolve<ConversationRestService>();
            MessageService = IoC.Resolve<MessageRestService>();
            ContactData = contactData;
            currentUser = me;
            NameLabel.Text = ContactData.Name;
            string hash = GravatarHelper.HashEmailForGravatar(ContactData.Email);
            avatar = GravatarHelper.GetGravatarImage(string.Format("http://www.gravatar.com/avatar/{0}?size=80", hash));
            online = contactData.IsOnline;
            if (!contactData.IsPerson)
            {
                RemoveEditButton.Content = "Edytuj";
                RemoveEditButton.Click += EditGroup_Click;
            }
            else
            {
                RemoveEditButton.Content = "Usuń";
                RemoveEditButton.Click += RemoveFriend_Click;
            }
            SetAvatar();
            var location = Assembly.GetEntryAssembly().Location;
            _soundDirectoryPath = Path.GetDirectoryName(location) + @"\Resources\sound\sound.wav";
        }

        public void UpdateName(string newName)
        {
            NameLabel.Text = newName;
        }

        public void UpdateAvatar(bool status)
        {
            if (online != status)
            {
                online = status;
                SetAvatar();
            }
        }

        private void SetAvatar()
        {
            if (!ContactData.IsPerson)
            {
                Avatar.ImageSource = avatar;
                OnlineIcon.Opacity = 0;
                NameLabel.Opacity = 1;
                return;
            }
            if (online || !ContactData.IsPerson)
            {
                Avatar.ImageSource = avatar;
                OnlineIcon.Opacity = 1;
                NameLabel.Opacity = 1;
            }
            else
            {
                this.Dispatcher.InvokeAsync((Action)(() =>
                {
                    Avatar.ImageSource = new FormatConvertedBitmap(avatar, PixelFormats.Gray32Float, null, 0);
                    OnlineIcon.Opacity = 0;
                    NameLabel.Opacity = 0.5;
                })).Task.Wait(100);
            }
        }

        public async void SetUnreadMessageIcon(IList<long?> unreadMessagesSenders)
        {
            if (ContactData.IsPerson) //nie wiadomo czemu nie dziala dla grup
            {
                ConversationsResponse conversationResponse = await ConversationService.GetConversationWithUser(ContactData.Id);
                for (int j = unreadMessagesSenders.Count - 1; j >= 0; j--)
                {
                    if (unreadMessagesSenders[j] == conversationResponse.Id)
                    {
                        IList<MessageModel> messages = await MessageService.Get20LastMessages(conversationResponse.Id);
                        if (messages[messages.Count - 1].UserId == ContactData.Id)
                        {
                            if (IsConversationWindowVisible)
                                conversationWindow.UpdateConversation();
                            else
                            {
                                SoundPlayer player = new SoundPlayer(_soundDirectoryPath);
                                player.Play();
								UnreadMessageIcon.Opacity = 1;
                            }
                            return;
                        }
                    }
                }
            }
            else
            {
                for (int j = unreadMessagesSenders.Count - 1; j >= 0; j--)
                {
                    if (unreadMessagesSenders[j] == ContactData.Id)
                    {
                        IList<MessageModel> messages = await MessageService.Get20LastMessages(ContactData.Id);
                        if (messages[messages.Count - 1].UserId != currentUser.Id)
                        {
                            if (IsConversationWindowVisible)
                                conversationWindow.UpdateConversation();
                            else
                                UnreadMessageIcon.Opacity = 1;
                            return;
                        }
                    }
                }
            }
            else
            {
                for (int j = unreadMessagesSenders.Count - 1; j >= 0; j--)
                {
                    if (unreadMessagesSenders[j] == ContactData.Id)
                    {
                        IList<MessageModel> messages = await MessageService.Get20LastMessages(ContactData.Id);
                        MessageBox.Show("SA NOWE");
                        if (messages[messages.Count - 1].UserId != currentUser.Id)
                        {
                            MessageBox.Show("OD KOGOS");
                            if (IsConversationWindowVisible)
                                conversationWindow.UpdateConversation();
                            else
                                UnreadMessageIcon.Opacity = 1;
                            return;
                        }
                    }
                }
            }
        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {
            new CreateEditGroupVM(ContactList.Instance.Contacts, ContactList.Instance, ContactData).Show();
        }

        private async void RemoveFriend_Click(object sender, RoutedEventArgs e)
        {
            await ContactListService.RemoveFriend(ContactData.Id);
            ContactList.Instance.RemoveContact(ContactData);
            ((StackPanel)this.Parent).Children.Remove(this);
        }

        private void MainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsConversationWindowVisible || !ConversationWindow.IsVisible)
            {
                IsConversationWindowVisible = true;
                conversationWindow = new MainWindow(currentUser, ContactData, this);
                conversationWindow.Title = ContactData.Name;
                ConversationWindow.Show();
                UnreadMessageIcon.Opacity = 0;
            }
            else
            {
                conversationWindow.Activate();
                UnreadMessageIcon.Opacity = 0;
            }
        }
    }
}
