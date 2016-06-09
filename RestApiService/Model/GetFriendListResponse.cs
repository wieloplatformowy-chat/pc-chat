using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiService.Model
{
    public class GetFriendListResponse
    {
        public IList<UserDTO> FriendList { get; set; }
    }
}
