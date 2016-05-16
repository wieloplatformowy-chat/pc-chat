using System;
using System.Net.Http;
using Czat.RestApiService.Model;
using Newtonsoft.Json;

namespace Czat.RestApiService
{
    public class ApiException : Exception
    {
        private ApiException(ApiError errorData)
        {
            ErrorData = errorData;
        }

        public ApiError ErrorData { get; set; }

        public static ApiException Create(HttpResponseMessage responseMsg)
        {
            var apiError = JsonConvert.DeserializeObject<ApiError>(responseMsg.Content.ReadAsStringAsync().Result);
            return new ApiException(apiError);
        }
    }
}