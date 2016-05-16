using System;
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

        private void Register()
        {
            try
            {
                Service.Login("testowyUser", "12345678");
                Service.DeleteAccount("12345678");
            }
            catch (Exception)
            {
                // ignored
            }
            Service.Register("testUser@test.pl", "testowyUser", "12345678");
        }

        private void Login()
        {
            Service.Login("testowyUser", "12345678");

            var userWithoutPasswordDto = Service.WhoAmI();
            Assert.AreEqual("testUser@test.pl", userWithoutPasswordDto.Email);
            Assert.AreEqual("testowyUser", userWithoutPasswordDto.Name);
            Assert.IsNotNull(Service.Client.Token);
        }

        private void Logout()
        {
            Service.Logout();

            try
            {
                Service.WhoAmI();
            }
            catch (ApiException ex)
            {
                Assert.AreEqual("LOGIN_REQUIRED", ex.ErrorData.Name);
            }
            Assert.IsNull(Service.Client.Token);
        }

        private void DeleteAccount()
        {
            Service.Login("testowyUser", "12345678");

            Service.DeleteAccount("12345678");
            Assert.IsNull(Service.Client.Token);
        }

        [Test]
        public void GeneralAccountFlow()
        {
            Register();
            Login();
            Logout();
            DeleteAccount();
        }
    }
}