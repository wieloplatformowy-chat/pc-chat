using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
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

        public async Task DeleteAccount(string password)
        {
            await Client.CallApiDeleteJson<GeneralStringResponse>(@"/user/delete", new {Password = password});
            Client.Token = null;
        }

        public async Task Login(string username, string password)
        {
            var loginParam = new LoginParam()
            {
                Name = username,
                Password = password
            };
            var response = await Client.CallApiPostJson<LoginResponse>(@"/user/login", loginParam);
            Client.Token = response.Token;
        }

        public async Task Logout()
        {
            await Client.CallGet<GeneralStringResponse>(@"/user/logout");
            Client.Token = null;
        }

        public async Task Register(string email, string name, string password)
        {
            var param = new RegisterParam()
            {
                Email = email,
                Name = name,
                Password = password
            };
            await Client.CallApiPostJson<LoginResponse>(@"/user/register", param);
        }

        public async Task<IList<UserDTO>> Search(SearchUserParam param)
        {
            return await Client.CallApiPostJson<IList<UserDTO>>(@"/user/search", param);
        }

        public async Task<UserDTO> WhoAmI()
        {
            return await Client.CallGet<UserDTO>(@"/user/whoami");
        }
    }
}