using Czat.Helpers;
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
        public CreateGroupVM(List<ContactListContactData> contacts)
        {
            InitializeComponent();
            GroupService = IoC.Resolve<GroupRestService>();
            Contacts = contacts;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
