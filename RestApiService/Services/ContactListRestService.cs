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

        public async Task<GetFriendListResponse> GetFriendList(string token)
        {
            var response = await Client.CallGet<GetFriendListResponse>($"/friends/my/{token}");
            return response;
        }
    }
}
