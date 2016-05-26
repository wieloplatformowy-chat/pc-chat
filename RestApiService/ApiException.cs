using System;
using System.Net.Http;
using Newtonsoft.Json;
using RestApiService.Model;

namespace RestApiService
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