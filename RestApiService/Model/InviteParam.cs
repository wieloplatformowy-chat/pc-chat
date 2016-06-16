using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiService.Model
{
    public class InviteParam
    {
        public long? GroupId { get; set; }
        public IList<long?> UserIds { get; set; }
    }
}
