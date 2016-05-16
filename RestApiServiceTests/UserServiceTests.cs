using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Czat.RestApiService;
using Czat.RestApiService.Services;

namespace RestApiServiceTests
{
    [TestFixture]
    public class UserServiceTests : ApiTestBase
    {
        public UserServiceTests()
        {
            Service = new UserRestService(Client);
        }

        public UserRestService Service { get; }

        private async Task Register()
        {
            try
            {
                await Service.Login("testowyUser", "12345678");
                await Service.DeleteAccount("12345678");
            }
            catch (Exception)
            {
                // ignored
            }
            await Service.Register("testUser@test.pl", "testowyUser", "12345678");
        }

        private async Task Login()
        {
            await Service.Login("testowyUser", "12345678");

            var userWithoutPasswordDto = await Service.WhoAmI();
            Assert.AreEqual("testUser@test.pl", userWithoutPasswordDto.Email);
            Assert.AreEqual("testowyUser", userWithoutPasswordDto.Name);
            Assert.IsNotNull(Service.Client.Token);
        }

        private async Task Logout()
        {
            await Service.Logout();

            try
            {
                await Service.WhoAmI();
            }
            catch (ApiException ex)
            {
                Assert.AreEqual("LOGIN_REQUIRED", ex.ErrorData.Name);
            }
            Assert.IsNull(Service.Client.Token);
        }

        private async Task DeleteAccount()
        {
            await Service.Login("testowyUser", "12345678");

            await Service.DeleteAccount("12345678");
            Assert.IsNull(Service.Client.Token);
        }

        [Test]
        public async Task GeneralAccountFlow()
        {
            await Register();
            await Login();
            await Logout();
            await DeleteAccount();
        }
    }
}