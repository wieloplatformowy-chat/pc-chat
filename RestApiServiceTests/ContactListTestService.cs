using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestApiService;
using RestApiService.Services;

namespace RestApiServiceTests
{
    [TestFixture]
    internal class ContactListTestService : ApiTestBase
    {

        public UserRestService UserService { get; }

        public ContactListRestService ContactListService { get; }

        public ContactListTestService()
        {
            UserService = new UserRestService(Client);
            ContactListService = new ContactListRestService(Client);
        }

        [Test]
        public async Task GetFriendListData()
        {
            await UserService.Login("test", "pass"); // id: 1291
            try
            {
                var response = await ContactListService.GetFriendList();
                Console.WriteLine(response);
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.ErrorData.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [Test]
        public async Task AddFriend()
        {
            await UserService.Login("1", "1");
            try
            {
                var response = await ContactListService.AddFriend(1291);
                Console.WriteLine(response.Response);
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.ErrorData.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                var response = await ContactListService.RemoveFriend(1291);
                Console.WriteLine(response.Response);
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.ErrorData.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
