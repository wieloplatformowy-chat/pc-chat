using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiService.Model;
namespace RestApiService.Services
{
    public class ContactListRestService
    {
        public ApiClient Client;

        public ContactListRestService(ApiClient client)
        {
            Client = client;
        }

        public async Task<IList<UserDTO>> GetFriendList()
        {
            var response = await Client.CallGet<IList<UserDTO>>($"/friends/my");
            return response;
        }

        public async Task<GeneralStringResponse> AddFriend(long? id)
        {
            var response = await Client.CallApiPostJson<GeneralStringResponse>($"/friends/add/{id}", new { ID = id });
            return response;
        }

        public async Task<GeneralStringResponse> RemoveFriend(long? id)
        {
            var response = await Client.CallApiDeleteJson<GeneralStringResponse>($"/friends/delete/{id}", new { ID = id });
            return response;
        }

        public async Task<bool> IsUserOnline(long? id)
        {
            var response = await Client.CallGet<bool>($"/friends/online/{id}");
            return response;
        }
    }
}
