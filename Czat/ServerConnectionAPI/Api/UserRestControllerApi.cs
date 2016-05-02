using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using Czat.ServerConnectionAPI.Client;
using Czat.ServerConnectionAPI.Model;

namespace Czat.ServerConnectionAPI.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUserRestControllerApi
    {
        #region Synchronous Operations
        
        /// <summary>
        /// login
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>DataResponsestring</returns>
        DataResponsestring LoginUsingPOST (UserDto userDto);
  
        /// <summary>
        /// login
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>ApiResponse of DataResponsestring</returns>
        ApiResponse<DataResponsestring> LoginUsingPOSTWithHttpInfo (UserDto userDto);
        
        /// <summary>
        /// register
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>BaseResponse</returns>
        BaseResponse RegisterUsingPOST (UserDto userDto);
  
        /// <summary>
        /// register
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>ApiResponse of BaseResponse</returns>
        ApiResponse<BaseResponse> RegisterUsingPOSTWithHttpInfo (UserDto userDto);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// login
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of DataResponsestring</returns>
        System.Threading.Tasks.Task<DataResponsestring> LoginUsingPOSTAsync (UserDto userDto);

        /// <summary>
        /// login
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of ApiResponse (DataResponsestring)</returns>
        System.Threading.Tasks.Task<ApiResponse<DataResponsestring>> LoginUsingPOSTAsyncWithHttpInfo (UserDto userDto);
        
        /// <summary>
        /// register
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of BaseResponse</returns>
        System.Threading.Tasks.Task<BaseResponse> RegisterUsingPOSTAsync (UserDto userDto);

        /// <summary>
        /// register
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of ApiResponse (BaseResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<BaseResponse>> RegisterUsingPOSTAsyncWithHttpInfo (UserDto userDto);
        
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
        /// login 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param> 
        /// <returns>DataResponsestring</returns>
        public DataResponsestring LoginUsingPOST (UserDto userDto)
        {
             ApiResponse<DataResponsestring> localVarResponse = LoginUsingPOSTWithHttpInfo(userDto);
             return localVarResponse.Data;
        }

        /// <summary>
        /// login 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param> 
        /// <returns>ApiResponse of DataResponsestring</returns>
        public ApiResponse< DataResponsestring > LoginUsingPOSTWithHttpInfo (UserDto userDto)
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
    
            return new ApiResponse<DataResponsestring>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DataResponsestring) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DataResponsestring)));
            
        }

        
        /// <summary>
        /// login 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of DataResponsestring</returns>
        public async System.Threading.Tasks.Task<DataResponsestring> LoginUsingPOSTAsync (UserDto userDto)
        {
             ApiResponse<DataResponsestring> localVarResponse = await LoginUsingPOSTAsyncWithHttpInfo(userDto);
             return localVarResponse.Data;

        }

        /// <summary>
        /// login 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of ApiResponse (DataResponsestring)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DataResponsestring>> LoginUsingPOSTAsyncWithHttpInfo (UserDto userDto)
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

            return new ApiResponse<DataResponsestring>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DataResponsestring) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DataResponsestring)));
            
        }
        
        /// <summary>
        /// register 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param> 
        /// <returns>BaseResponse</returns>
        public BaseResponse RegisterUsingPOST (UserDto userDto)
        {
             ApiResponse<BaseResponse> localVarResponse = RegisterUsingPOSTWithHttpInfo(userDto);
             return localVarResponse.Data;
        }

        /// <summary>
        /// register 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param> 
        /// <returns>ApiResponse of BaseResponse</returns>
        public ApiResponse< BaseResponse > RegisterUsingPOSTWithHttpInfo (UserDto userDto)
        {
            
            // verify the required parameter 'userDto' is set
            if (userDto == null)
                throw new ApiException(400, "Missing required parameter 'userDto' when calling UserrestcontrollerApi->RegisterUsingPOST");
            
    
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
                throw new ApiException (localVarStatusCode, "Error calling RegisterUsingPOST: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling RegisterUsingPOST: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<BaseResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (BaseResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(BaseResponse)));
            
        }

        
        /// <summary>
        /// register 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of BaseResponse</returns>
        public async System.Threading.Tasks.Task<BaseResponse> RegisterUsingPOSTAsync (UserDto userDto)
        {
             ApiResponse<BaseResponse> localVarResponse = await RegisterUsingPOSTAsyncWithHttpInfo(userDto);
             return localVarResponse.Data;

        }

        /// <summary>
        /// register 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userDto">userDto</param>
        /// <returns>Task of ApiResponse (BaseResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<BaseResponse>> RegisterUsingPOSTAsyncWithHttpInfo (UserDto userDto)
        {
            // verify the required parameter 'userDto' is set
            if (userDto == null) throw new ApiException(400, "Missing required parameter 'userDto' when calling RegisterUsingPOST");
            
    
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
                throw new ApiException (localVarStatusCode, "Error calling RegisterUsingPOST: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling RegisterUsingPOST: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<BaseResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (BaseResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(BaseResponse)));
            
        }
        
    }
    
}
