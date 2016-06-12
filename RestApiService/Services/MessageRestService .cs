using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiService.Model;

namespace RestApiService.Services
{
    public class MessageRestService
    {
        public ApiClient Client { get; }

        public MessageRestService(ApiClient client)
        {
            Client = client;
        }

        public async Task<IList<MessageModel>> Get20OlderMessages(long? conversationId, long? messageId)
        {
            var response = await Client.CallGet<IList<MessageModel>>($"/messages/before/{conversationId}/{messageId}");
            return response;
        }

        public async Task<IList<MessageModel>> Get20LastMessages(long? conversationId)
        {
            var response = await Client.CallGet<IList<MessageModel>>($"/messages/last/{conversationId}");
            return response;
        }

        public async Task SendMessage(long? conversationId, string message)
        {
            SendMessageParam param = new SendMessageParam()
            {
                ConversationId = conversationId,
                Message = message
            };
            var response = await Client.CallApiPostJson<GeneralStringResponse>(@"/messages/send", param);
        }
    }
}
