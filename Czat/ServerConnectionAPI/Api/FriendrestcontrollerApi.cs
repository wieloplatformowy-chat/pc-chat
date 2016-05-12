using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Czat.ServerConnectionAPI.Client;
using Czat.ServerConnectionAPI.Model;
using RestResponse = Czat.ServerConnectionAPI.Model.RestResponse;

namespace Czat.ServerConnectionAPI.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFriendRestControllerApi
    {
        #region Synchronous Operations

        /// <summary>
        /// Lists all friends of logged user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>List&lt;UserWithoutPasswordDto&gt;</returns>
        List<UserWithoutPasswordDto> MyUsingGET(string xAuthToken = null);

        /// <summary>
        /// Lists all friends of logged user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>ApiResponse of List&lt;UserWithoutPasswordDto&gt;</returns>
        ApiResponse<List<UserWithoutPasswordDto>> MyUsingGETWithHttpInfo(string xAuthToken = null);

        /// <summary>
        /// Adds friend for logged user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="idDto">idDto</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>RestResponse</returns>
        RestResponse RegisterUsingPOST(IdDto idDto, string xAuthToken = null);

        /// <summary>
        /// Adds friend for logged user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="idDto">idDto</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>ApiResponse of RestResponse</returns>
        ApiResponse<RestResponse> RegisterUsingPOSTWithHttpInfo(IdDto idDto, string xAuthToken = null);

        #endregion Synchronous Operations

        #region Asynchronous Operations

        /// <summary>
        /// Lists all friends of logged user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of List&lt;UserWithoutPasswordDto&gt;</returns>
        System.Threading.Tasks.Task<List<UserWithoutPasswordDto>> MyUsingGETAsync(string xAuthToken = null);

        /// <summary>
        /// Lists all friends of logged user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;UserWithoutPasswordDto&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<UserWithoutPasswordDto>>> MyUsingGETAsyncWithHttpInfo(string xAuthToken = null);

        /// <summary>
        /// Adds friend for logged user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="idDto">idDto</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of RestResponse</returns>
        System.Threading.Tasks.Task<RestResponse> RegisterUsingPOSTAsync(IdDto idDto, string xAuthToken = null);

        /// <summary>
        /// Adds friend for logged user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="idDto">idDto</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (RestResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<RestResponse>> RegisterUsingPOSTAsyncWithHttpInfo(IdDto idDto, string xAuthToken = null);

        #endregion Asynchronous Operations

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class FriendRestControllerApi : IFriendRestControllerApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FriendRestControllerApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FriendRestControllerApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FriendRestControllerApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public FriendRestControllerApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuraiton.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }


        /// <summary>
        /// Lists all friends of logged user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>List&lt;UserWithoutPasswordDto&gt;</returns>
        public List<UserWithoutPasswordDto> MyUsingGET(string xAuthToken = null)
        {
            ApiResponse<List<UserWithoutPasswordDto>> localVarResponse = MyUsingGETWithHttpInfo(xAuthToken);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Lists all friends of logged user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>ApiResponse of List&lt;UserWithoutPasswordDto&gt;</returns>
        public ApiResponse<List<UserWithoutPasswordDto>> MyUsingGETWithHttpInfo(string xAuthToken = null)
        {


            var localVarPath = "/friends/my";

            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");


            if (xAuthToken != null) localVarHeaderParams.Add("X-Auth-Token", Configuration.ApiClient.ParameterToString(xAuthToken)); // header parameter






            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException(localVarStatusCode, "Error calling MyUsingGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling MyUsingGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<UserWithoutPasswordDto>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<UserWithoutPasswordDto>)Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<UserWithoutPasswordDto>)));

        }


        /// <summary>
        /// Lists all friends of logged user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of List&lt;UserWithoutPasswordDto&gt;</returns>
        public async System.Threading.Tasks.Task<List<UserWithoutPasswordDto>> MyUsingGETAsync(string xAuthToken = null)
        {
            ApiResponse<List<UserWithoutPasswordDto>> localVarResponse = await MyUsingGETAsyncWithHttpInfo(xAuthToken);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Lists all friends of logged user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;UserWithoutPasswordDto&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<UserWithoutPasswordDto>>> MyUsingGETAsyncWithHttpInfo(string xAuthToken = null)
        {


            var localVarPath = "/friends/my";

            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");


            if (xAuthToken != null) localVarHeaderParams.Add("X-Auth-Token", Configuration.ApiClient.ParameterToString(xAuthToken)); // header parameter






            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException(localVarStatusCode, "Error calling MyUsingGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling MyUsingGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<UserWithoutPasswordDto>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<UserWithoutPasswordDto>)Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<UserWithoutPasswordDto>)));

        }

        /// <summary>
        /// Adds friend for logged user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="idDto">idDto</param> 
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>RestResponse</returns>
        public RestResponse RegisterUsingPOST(IdDto idDto, string xAuthToken = null)
        {
            ApiResponse<RestResponse> localVarResponse = RegisterUsingPOSTWithHttpInfo(idDto, xAuthToken);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Adds friend for logged user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="idDto">idDto</param> 
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>ApiResponse of RestResponse</returns>
        public ApiResponse<RestResponse> RegisterUsingPOSTWithHttpInfo(IdDto idDto, string xAuthToken = null)
        {

            // verify the required parameter 'idDto' is set
            if (idDto == null)
                throw new ApiException(400, "Missing required parameter 'idDto' when calling FriendrestcontrollerApi->RegisterUsingPOST");


            var localVarPath = "/friends/add";

            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");


            if (xAuthToken != null) localVarHeaderParams.Add("X-Auth-Token", Configuration.ApiClient.ParameterToString(xAuthToken)); // header parameter


            if (idDto.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(idDto); // http body (model) parameter
            }
            else
            {
                localVarPostBody = idDto; // byte array
            }



            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException(localVarStatusCode, "Error calling RegisterUsingPOST: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling RegisterUsingPOST: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<RestResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (RestResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(RestResponse)));

        }


        /// <summary>
        /// Adds friend for logged user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="idDto">idDto</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of RestResponse</returns>
        public async System.Threading.Tasks.Task<RestResponse> RegisterUsingPOSTAsync(IdDto idDto, string xAuthToken = null)
        {
            ApiResponse<RestResponse> localVarResponse = await RegisterUsingPOSTAsyncWithHttpInfo(idDto, xAuthToken);
            return localVarResponse.Data;

        }

        /// <summary>
        /// Adds friend for logged user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="idDto">idDto</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (RestResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<RestResponse>> RegisterUsingPOSTAsyncWithHttpInfo(IdDto idDto, string xAuthToken = null)
        {
            // verify the required parameter 'idDto' is set
            if (idDto == null) throw new ApiException(400, "Missing required parameter 'idDto' when calling RegisterUsingPOST");


            var localVarPath = "/friends/add";

            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");


            if (xAuthToken != null) localVarHeaderParams.Add("X-Auth-Token", Configuration.ApiClient.ParameterToString(xAuthToken)); // header parameter


            if (idDto.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(idDto); // http body (model) parameter
            }
            else
            {
                localVarPostBody = idDto; // byte array
            }



            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException(localVarStatusCode, "Error calling RegisterUsingPOST: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException(localVarStatusCode, "Error calling RegisterUsingPOST: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<RestResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (RestResponse)Configuration.ApiClient.Deserialize(localVarResponse, typeof(RestResponse)));

        }

    }

}
