using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiService.Model
{
    public class SendMessageParam
    {
        public long? ConversationId { get; set; }
        public string Message { get; set; }
    }
}
