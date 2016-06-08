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
    internal class ConversationServiceTest : ApiTestBase
    {

        public UserRestService UserService { get; }

        public ConversationRestService ConversationService { get; }

        public ConversationServiceTest()
        {
            UserService = new UserRestService(Client);
            ConversationService = new ConversationRestService(Client);
        }

        [Test]
        public async Task GetConversationData()
        {
            //await UserService.Login("abcd", "abcd"); // id: 1670
            //var user = await UserService.WhoAmI();
            //var firstUserId = user.Id ?? 0;
            //await UserService.Logout();

            await UserService.Login("test", "pass"); // id: 1291
            try
            {
                var response = await ConversationService.GetConversationWithUser(1670);
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
    }
}