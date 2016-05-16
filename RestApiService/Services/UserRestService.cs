using System.Collections.Generic;
using System.Security;
using Czat.RestApiService.Model;

namespace Czat.RestApiService.Services
{
    public class UserRestService
    {
        public UserRestService(ApiClient client)
        {
            Client = client;
        }

        public ApiClient Client { get; }

        public void DeleteAccount(string password)
        {
            Client.CallApiDeleteJson<GeneralStringResponse>(@"/user/delete", new {Password = password});
            Client.Token = null;
        }

        public void Login(string username, string password)
        {
            var loginParam = new LoginParam()
            {
                Name = username,
                Password = password
            };
            var response = Client.CallApiPostJson<LoginResponse>(@"/user/login", loginParam);
            Client.Token = response.Token;
        }

        public void Logout()
        {
            Client.CallGet<GeneralStringResponse>(@"/user/logout");
            Client.Token = null;
        }

        public void Register(string email, string name, string password)
        {
            var param = new RegisterParam()
            {
                Email = email,
                Name = name,
                Password = password
            };
            Client.CallApiPostJson<LoginResponse>(@"/user/register", param);
        }

        public IList<UserDTO> Search(SearchUserParam param)
        {
            return Client.CallApiPostJson<IList<UserDTO>>(@"/user/search", param);
        }

        public UserDTO WhoAmI()
        {
            return Client.CallGet<UserDTO>(@"/user/whoami");
        }
    }
}