using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public interface IUserRestControllerApi
    {
        #region Synchronous Operations
        
        /// <summary>
        /// Delete user
        /// </summary>
        /// <remarks>
        /// throws: UNKNOWN_ERROR, INVALID_JSON
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restData">restData</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>RestResponse</returns>
        RestResponse DeleteUsingDELETE (PasswordDto restData, string xAuthToken = null);
  
        /// <summary>
        /// Delete user
        /// </summary>
        /// <remarks>
        /// throws: UNKNOWN_ERROR, INVALID_JSON
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restData">restData</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>ApiResponse of RestResponse</returns>
        ApiResponse<RestResponse> DeleteUsingDELETEWithHttpInfo (PasswordDto restData, string xAuthToken = null);
        
        /// <summary>
        /// Login user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>TokenDto</returns>
        TokenDto LoginUsingPOST (LoginDto userDto);
  
        /// <summary>
        /// Login user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>ApiResponse of TokenDto</returns>
        ApiResponse<TokenDto> LoginUsingPOSTWithHttpInfo (LoginDto userDto);
        
        /// <summary>
        /// Logout user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>RestResponse</returns>
        RestResponse LogoutUsingGET (string xAuthToken = null);
  
        /// <summary>
        /// Logout user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>ApiResponse of RestResponse</returns>
        ApiResponse<RestResponse> LogoutUsingGETWithHttpInfo (string xAuthToken = null);
        
        /// <summary>
        /// Register user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>RestResponse</returns>
        RestResponse RegisterUsingPOST1 (UserDto userDto);
  
        /// <summary>
        /// Register user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>ApiResponse of RestResponse</returns>
        ApiResponse<RestResponse> RegisterUsingPOST1WithHttpInfo (UserDto userDto);
        
        /// <summary>
        /// Search for users with given name and email
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">search</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>List&lt;UserWithoutPasswordDto&gt;</returns>
        List<UserWithoutPasswordDto> SearchUsingPOST (SearchUserDto search, string xAuthToken = null);
  
        /// <summary>
        /// Search for users with given name and email
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">search</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>ApiResponse of List&lt;UserWithoutPasswordDto&gt;</returns>
        ApiResponse<List<UserWithoutPasswordDto>> SearchUsingPOSTWithHttpInfo (SearchUserDto search, string xAuthToken = null);
        
        /// <summary>
        /// Returns user associated with given token
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>UserWithoutPasswordDto</returns>
        UserWithoutPasswordDto WhoAmIUsingGET (string xAuthToken = null);
  
        /// <summary>
        /// Returns user associated with given token
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>ApiResponse of UserWithoutPasswordDto</returns>
        ApiResponse<UserWithoutPasswordDto> WhoAmIUsingGETWithHttpInfo (string xAuthToken = null);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// Delete user
        /// </summary>
        /// <remarks>
        /// throws: UNKNOWN_ERROR, INVALID_JSON
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restData">restData</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of RestResponse</returns>
        System.Threading.Tasks.Task<RestResponse> DeleteUsingDELETEAsync (PasswordDto restData, string xAuthToken = null);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <remarks>
        /// throws: UNKNOWN_ERROR, INVALID_JSON
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restData">restData</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (RestResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<RestResponse>> DeleteUsingDELETEAsyncWithHttpInfo (PasswordDto restData, string xAuthToken = null);
        
        /// <summary>
        /// Login user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of TokenDto</returns>
        System.Threading.Tasks.Task<TokenDto> LoginUsingPOSTAsync (LoginDto userDto);

        /// <summary>
        /// Login user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of ApiResponse (TokenDto)</returns>
        System.Threading.Tasks.Task<ApiResponse<TokenDto>> LoginUsingPOSTAsyncWithHttpInfo (LoginDto userDto);
        
        /// <summary>
        /// Logout user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of RestResponse</returns>
        System.Threading.Tasks.Task<RestResponse> LogoutUsingGETAsync (string xAuthToken = null);

        /// <summary>
        /// Logout user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (RestResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<RestResponse>> LogoutUsingGETAsyncWithHttpInfo (string xAuthToken = null);
        
        /// <summary>
        /// Register user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of RestResponse</returns>
        System.Threading.Tasks.Task<RestResponse> RegisterUsingPOST1Async (UserDto userDto);

        /// <summary>
        /// Register user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of ApiResponse (RestResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<RestResponse>> RegisterUsingPOST1AsyncWithHttpInfo (UserDto userDto);
        
        /// <summary>
        /// Search for users with given name and email
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">search</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of List&lt;UserWithoutPasswordDto&gt;</returns>
        System.Threading.Tasks.Task<List<UserWithoutPasswordDto>> SearchUsingPOSTAsync (SearchUserDto search, string xAuthToken = null);

        /// <summary>
        /// Search for users with given name and email
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">search</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;UserWithoutPasswordDto&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<UserWithoutPasswordDto>>> SearchUsingPOSTAsyncWithHttpInfo (SearchUserDto search, string xAuthToken = null);
        
        /// <summary>
        /// Returns user associated with given token
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of UserWithoutPasswordDto</returns>
        System.Threading.Tasks.Task<UserWithoutPasswordDto> WhoAmIUsingGETAsync (string xAuthToken = null);

        /// <summary>
        /// Returns user associated with given token
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (UserWithoutPasswordDto)</returns>
        System.Threading.Tasks.Task<ApiResponse<UserWithoutPasswordDto>> WhoAmIUsingGETAsyncWithHttpInfo (string xAuthToken = null);
        
        #endregion Asynchronous Operations
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UserRestControllerApi : IUserRestControllerApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRestControllerApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UserRestControllerApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRestControllerApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public UserRestControllerApi(Configuration configuration = null)
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
        public Configuration Configuration {get; set;}

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
        /// Delete user throws: UNKNOWN_ERROR, INVALID_JSON
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restData">restData</param> 
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>RestResponse</returns>
        public RestResponse DeleteUsingDELETE (PasswordDto restData, string xAuthToken = null)
        {
             ApiResponse<RestResponse> localVarResponse = DeleteUsingDELETEWithHttpInfo(restData, xAuthToken);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete user throws: UNKNOWN_ERROR, INVALID_JSON
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restData">restData</param> 
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>ApiResponse of RestResponse</returns>
        public ApiResponse< RestResponse > DeleteUsingDELETEWithHttpInfo (PasswordDto restData, string xAuthToken = null)
        {
            
            // verify the required parameter 'restData' is set
            if (restData == null)
                throw new ApiException(400, "Missing required parameter 'restData' when calling UserrestcontrollerApi->DeleteUsingDELETE");
            
    
            var localVarPath = "/user/delete";
    
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
            
            
            if (restData.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(restData); // http body (model) parameter
            }
            else
            {
                localVarPostBody = restData; // byte array
            }

            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeleteUsingDELETE: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeleteUsingDELETE: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<RestResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (RestResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(RestResponse)));
            
        }

        
        /// <summary>
        /// Delete user throws: UNKNOWN_ERROR, INVALID_JSON
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restData">restData</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of RestResponse</returns>
        public async System.Threading.Tasks.Task<RestResponse> DeleteUsingDELETEAsync (PasswordDto restData, string xAuthToken = null)
        {
             ApiResponse<RestResponse> localVarResponse = await DeleteUsingDELETEAsyncWithHttpInfo(restData, xAuthToken);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete user throws: UNKNOWN_ERROR, INVALID_JSON
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="restData">restData</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (RestResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<RestResponse>> DeleteUsingDELETEAsyncWithHttpInfo (PasswordDto restData, string xAuthToken = null)
        {
            // verify the required parameter 'restData' is set
            if (restData == null) throw new ApiException(400, "Missing required parameter 'restData' when calling DeleteUsingDELETE");
            
    
            var localVarPath = "/user/delete";
    
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
            
            
            if (restData.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(restData); // http body (model) parameter
            }
            else
            {
                localVarPostBody = restData; // byte array
            }

            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeleteUsingDELETE: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeleteUsingDELETE: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<RestResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (RestResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(RestResponse)));
            
        }
        
        /// <summary>
        /// Login user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param> 
        /// <returns>TokenDto</returns>
        public TokenDto LoginUsingPOST (LoginDto userDto)
        {
             ApiResponse<TokenDto> localVarResponse = LoginUsingPOSTWithHttpInfo(userDto);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Login user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param> 
        /// <returns>ApiResponse of TokenDto</returns>
        public ApiResponse< TokenDto > LoginUsingPOSTWithHttpInfo (LoginDto userDto)
        {
            
            // verify the required parameter 'userDto' is set
            if (userDto == null)
                throw new ApiException(400, "Missing required parameter 'userDto' when calling UserrestcontrollerApi->LoginUsingPOST");
            
    
            var localVarPath = "/user/login";
    
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
            
            
            
            
            if (userDto.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(userDto); // http body (model) parameter
            }
            else
            {
                localVarPostBody = userDto; // byte array
            }

            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling LoginUsingPOST: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling LoginUsingPOST: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<TokenDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (TokenDto) Configuration.ApiClient.Deserialize(localVarResponse, typeof(TokenDto)));
            
        }

        
        /// <summary>
        /// Login user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of TokenDto</returns>
        public async System.Threading.Tasks.Task<TokenDto> LoginUsingPOSTAsync (LoginDto userDto)
        {
             ApiResponse<TokenDto> localVarResponse = await LoginUsingPOSTAsyncWithHttpInfo(userDto);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Login user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of ApiResponse (TokenDto)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<TokenDto>> LoginUsingPOSTAsyncWithHttpInfo (LoginDto userDto)
        {
            // verify the required parameter 'userDto' is set
            if (userDto == null) throw new ApiException(400, "Missing required parameter 'userDto' when calling LoginUsingPOST");
            
    
            var localVarPath = "/user/login";
    
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
            
            
            
            
            if (userDto.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(userDto); // http body (model) parameter
            }
            else
            {
                localVarPostBody = userDto; // byte array
            }

            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling LoginUsingPOST: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling LoginUsingPOST: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<TokenDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (TokenDto) Configuration.ApiClient.Deserialize(localVarResponse, typeof(TokenDto)));
            
        }
        
        /// <summary>
        /// Logout user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>RestResponse</returns>
        public RestResponse LogoutUsingGET (string xAuthToken = null)
        {
             ApiResponse<RestResponse> localVarResponse = LogoutUsingGETWithHttpInfo(xAuthToken);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Logout user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>ApiResponse of RestResponse</returns>
        public ApiResponse< RestResponse > LogoutUsingGETWithHttpInfo (string xAuthToken = null)
        {
            
    
            var localVarPath = "/user/logout";
    
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
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling LogoutUsingGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling LogoutUsingGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<RestResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (RestResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(RestResponse)));
            
        }

        
        /// <summary>
        /// Logout user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of RestResponse</returns>
        public async System.Threading.Tasks.Task<RestResponse> LogoutUsingGETAsync (string xAuthToken = null)
        {
             ApiResponse<RestResponse> localVarResponse = await LogoutUsingGETAsyncWithHttpInfo(xAuthToken);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Logout user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (RestResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<RestResponse>> LogoutUsingGETAsyncWithHttpInfo (string xAuthToken = null)
        {
            
    
            var localVarPath = "/user/logout";
    
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
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling LogoutUsingGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling LogoutUsingGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<RestResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (RestResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(RestResponse)));
            
        }
        
        /// <summary>
        /// Register user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param> 
        /// <returns>RestResponse</returns>
        public RestResponse RegisterUsingPOST1 (UserDto userDto)
        {
             ApiResponse<RestResponse> localVarResponse = RegisterUsingPOST1WithHttpInfo(userDto);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Register user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param> 
        /// <returns>ApiResponse of RestResponse</returns>
        public ApiResponse< RestResponse > RegisterUsingPOST1WithHttpInfo (UserDto userDto)
        {
            
            // verify the required parameter 'userDto' is set
            if (userDto == null)
                throw new ApiException(400, "Missing required parameter 'userDto' when calling UserrestcontrollerApi->RegisterUsingPOST1");
            
    
            var localVarPath = "/user/register";
    
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
            
            
            
            
            if (userDto.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(userDto); // http body (model) parameter
            }
            else
            {
                localVarPostBody = userDto; // byte array
            }

            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling RegisterUsingPOST1: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling RegisterUsingPOST1: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<RestResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (RestResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(RestResponse)));
            
        }

        
        /// <summary>
        /// Register user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of RestResponse</returns>
        public async System.Threading.Tasks.Task<RestResponse> RegisterUsingPOST1Async (UserDto userDto)
        {
             ApiResponse<RestResponse> localVarResponse = await RegisterUsingPOST1AsyncWithHttpInfo(userDto);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Register user 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of ApiResponse (RestResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<RestResponse>> RegisterUsingPOST1AsyncWithHttpInfo (UserDto userDto)
        {
            // verify the required parameter 'userDto' is set
            if (userDto == null) throw new ApiException(400, "Missing required parameter 'userDto' when calling RegisterUsingPOST1");
            
    
            var localVarPath = "/user/register";
    
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
            
            
            
            
            if (userDto.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(userDto); // http body (model) parameter
            }
            else
            {
                localVarPostBody = userDto; // byte array
            }

            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling RegisterUsingPOST1: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling RegisterUsingPOST1: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<RestResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (RestResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(RestResponse)));
            
        }
        
        /// <summary>
        /// Search for users with given name and email 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">search</param> 
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>List&lt;UserWithoutPasswordDto&gt;</returns>
        public List<UserWithoutPasswordDto> SearchUsingPOST (SearchUserDto search, string xAuthToken = null)
        {
             ApiResponse<List<UserWithoutPasswordDto>> localVarResponse = SearchUsingPOSTWithHttpInfo(search, xAuthToken);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Search for users with given name and email 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">search</param> 
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>ApiResponse of List&lt;UserWithoutPasswordDto&gt;</returns>
        public ApiResponse< List<UserWithoutPasswordDto> > SearchUsingPOSTWithHttpInfo (SearchUserDto search, string xAuthToken = null)
        {
            
            // verify the required parameter 'search' is set
            if (search == null)
                throw new ApiException(400, "Missing required parameter 'search' when calling UserrestcontrollerApi->SearchUsingPOST");
            
    
            var localVarPath = "/user/search";
    
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
            
            
            if (search.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(search); // http body (model) parameter
            }
            else
            {
                localVarPostBody = search; // byte array
            }

            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling SearchUsingPOST: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling SearchUsingPOST: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<List<UserWithoutPasswordDto>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<UserWithoutPasswordDto>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<UserWithoutPasswordDto>)));
            
        }

        
        /// <summary>
        /// Search for users with given name and email 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">search</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of List&lt;UserWithoutPasswordDto&gt;</returns>
        public async System.Threading.Tasks.Task<List<UserWithoutPasswordDto>> SearchUsingPOSTAsync (SearchUserDto search, string xAuthToken = null)
        {
             ApiResponse<List<UserWithoutPasswordDto>> localVarResponse = await SearchUsingPOSTAsyncWithHttpInfo(search, xAuthToken);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Search for users with given name and email 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">search</param>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;UserWithoutPasswordDto&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<UserWithoutPasswordDto>>> SearchUsingPOSTAsyncWithHttpInfo (SearchUserDto search, string xAuthToken = null)
        {
            // verify the required parameter 'search' is set
            if (search == null) throw new ApiException(400, "Missing required parameter 'search' when calling SearchUsingPOST");
            
    
            var localVarPath = "/user/search";
    
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
            
            
            if (search.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(search); // http body (model) parameter
            }
            else
            {
                localVarPostBody = search; // byte array
            }

            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling SearchUsingPOST: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling SearchUsingPOST: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<UserWithoutPasswordDto>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<UserWithoutPasswordDto>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<UserWithoutPasswordDto>)));
            
        }
        
        /// <summary>
        /// Returns user associated with given token 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>UserWithoutPasswordDto</returns>
        public UserWithoutPasswordDto WhoAmIUsingGET (string xAuthToken = null)
        {
             ApiResponse<UserWithoutPasswordDto> localVarResponse = WhoAmIUsingGETWithHttpInfo(xAuthToken);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Returns user associated with given token 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param> 
        /// <returns>ApiResponse of UserWithoutPasswordDto</returns>
        public ApiResponse< UserWithoutPasswordDto > WhoAmIUsingGETWithHttpInfo (string xAuthToken = null)
        {
            
    
            var localVarPath = "/user/whoami";
    
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
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling WhoAmIUsingGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling WhoAmIUsingGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<UserWithoutPasswordDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserWithoutPasswordDto) Configuration.ApiClient.Deserialize(localVarResponse, typeof(UserWithoutPasswordDto)));
            
        }

        
        /// <summary>
        /// Returns user associated with given token 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of UserWithoutPasswordDto</returns>
        public async System.Threading.Tasks.Task<UserWithoutPasswordDto> WhoAmIUsingGETAsync (string xAuthToken = null)
        {
             ApiResponse<UserWithoutPasswordDto> localVarResponse = await WhoAmIUsingGETAsyncWithHttpInfo(xAuthToken);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Returns user associated with given token 
        /// </summary>
        /// <exception cref="Czat.ServerConnectionAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xAuthToken">Authorization token (optional)</param>
        /// <returns>Task of ApiResponse (UserWithoutPasswordDto)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<UserWithoutPasswordDto>> WhoAmIUsingGETAsyncWithHttpInfo (string xAuthToken = null)
        {
            
    
            var localVarPath = "/user/whoami";
    
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
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling WhoAmIUsingGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling WhoAmIUsingGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<UserWithoutPasswordDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserWithoutPasswordDto) Configuration.ApiClient.Deserialize(localVarResponse, typeof(UserWithoutPasswordDto)));
            
        }
        
    }
    
}
