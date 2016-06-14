using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiService.Model
{
    public class MessageModel
    {
        public long? ConversationId { get; set; }
        public long? Date { get; set; }
        public long? Id { get; set; }
        public string Message { get; set; }
        public long? UserId { get; set; }
    }
}
