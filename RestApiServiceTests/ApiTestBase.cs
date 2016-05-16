using Czat.RestApiService;
using Czat.RestApiService.Model;

namespace RestApiServiceTests
{
    public class ApiTestBase
    {
        public ApiTestBase()
        {
            Client = new ApiClient(@"http://chatbackend-chat22.rhcloud.com:80/");
        }

        public ApiClient Client { get; }
    }
}