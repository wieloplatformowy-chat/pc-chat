using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestApiService;
using RestApiService.Services;

namespace RestApiServiceTests
{
    [TestFixture]
    internal class MessageServiceTest : ApiTestBase
    {

        public UserRestService UserService { get; }

        public MessageRestService MessageService  { get; }

        public MessageServiceTest()
        {
            UserService = new UserRestService(Client);
            MessageService = new MessageRestService(Client);
        }
    }
}
