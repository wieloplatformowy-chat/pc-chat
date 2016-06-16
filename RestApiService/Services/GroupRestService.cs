using RestApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiService.Services
{
    public class GroupRestService
    {
        public ApiClient Client { get; }

        public GroupRestService(ApiClient client)
        {
            Client = client;
        }

        public async Task<IdResponse> CreateNewGroup()
        {
            var response = await Client.CallGet<IdResponse>("/groups/create");
            return response;
        }

        public async Task<GeneralStringResponse> InviteUserToGroup(long? groupId, List<long?> usersIds)
        {
            InviteParam param = new InviteParam
            {
                GroupId = groupId,
                UserIds = usersIds
            };
            var response = await Client.CallApiPostJson<GeneralStringResponse>("/groups/invite", param);
            return response;
        }

        public async Task<IList<GroupDTO>> GetGroups()
        {
            var response = await Client.CallGet<IList<GroupDTO>>($"/groups/my");
            return response;
        }

        public async Task<GeneralStringResponse> ChangeConversationName(long? groupId, string newName)
        {
            RenameParam param = new RenameParam
            {
                GroupId = groupId,
                NewName = newName
            };
            var response = await Client.CallApiPostJson<GeneralStringResponse>($"/groups/rename", param);
            return response;
        }
    }
}
