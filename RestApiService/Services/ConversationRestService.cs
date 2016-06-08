using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiService.Model;

namespace RestApiService.Services
{
    public class ConversationRestService
    {
        public ApiClient Client { get; }

        public ConversationRestService(ApiClient client)
        {
            Client = client;
        }

        public async Task<ConversationsResponse> GetConversationWithUser(long userId)
        {
            var response = await Client.CallGet<ConversationsResponse>($"/conversations/{userId}");
            return response;
        }
    }
}