using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Czat.RestApiService
{
    public class ApiClient
    {
        public ApiClient(string apiUrl)
        {
            ApiUrl = new Uri(apiUrl);
        }

        public string Token { get; set; }

        public Uri ApiUrl { get; }

        private T CallApi<T>(string url, HttpMethod method, object json = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = ApiUrl;
                SetToken<T>(client);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpRequestMessage = new HttpRequestMessage(method, new Uri(url, UriKind.Relative));
                PrepareRequestmessege(json, httpRequestMessage);
                var responseMsg = client.SendAsync(httpRequestMessage).Result;


                if (!responseMsg.IsSuccessStatusCode)
                {
                    throw ApiException.Create(responseMsg);
                }

                return JsonConvert.DeserializeObject<T>(responseMsg.Content.ReadAsStringAsync().Result);
            }
        }

        private static void PrepareRequestmessege(object json, HttpRequestMessage httpRequestMessage)
        {
            if (json == null)
            {
                return;
            }
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var jsonBody = JsonConvert.SerializeObject(json, settings);
            var httpContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = httpContent;
        }

        protected void SetToken<T>(HttpClient client)
        {
            if (Token != null)
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", Token);
            }
        }

        public T CallGet<T>(string url)
        {
            return CallApi<T>(url,HttpMethod.Get);
        }

        public T CallApiPostJson<T>(string url, object json)
        {
            return CallApi<T>(url,HttpMethod.Post,json);
        }


        public T CallApiDelete<T>(string url)
        {
            return CallApi<T>(url,HttpMethod.Delete);
        }

        public T CallApiDeleteJson<T>(string url, object json)
        {
            return CallApi<T>(url,HttpMethod.Delete,json);
        }
    }
}