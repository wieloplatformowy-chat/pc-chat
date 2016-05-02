using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using ServerConnection.Client;
using ServerConnection.Model;

namespace ServerConnection.Swagger.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITokenRestControllerApi
    {
        #region Synchronous Operations
        
        /// <summary>
        /// checkToken
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>DataResponsestring</returns>
        DataResponsestring CheckTokenUsingGET ();
  
        /// <summary>
        /// checkToken
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of DataResponsestring</returns>
        ApiResponse<DataResponsestring> CheckTokenUsingGETWithHttpInfo ();
        
        /// <summary>
        /// version
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>string</returns>
        string VersionUsingPATCH ();
  
        /// <summary>
        /// version
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> VersionUsingPATCHWithHttpInfo ();
        
        /// <summary>
        /// whoAmI
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>DataResponseUserEntity</returns>
        DataResponseUserEntity WhoAmIUsingGET ();
  
        /// <summary>
        /// whoAmI
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of DataResponseUserEntity</returns>
        ApiResponse<DataResponseUserEntity> WhoAmIUsingGETWithHttpInfo ();
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// checkToken
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of DataResponsestring</returns>
        System.Threading.Tasks.Task<DataResponsestring> CheckTokenUsingGETAsync ();

        /// <summary>
        /// checkToken
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (DataResponsestring)</returns>
        System.Threading.Tasks.Task<ApiResponse<DataResponsestring>> CheckTokenUsingGETAsyncWithHttpInfo ();
        
        /// <summary>
        /// version
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> VersionUsingPATCHAsync ();

        /// <summary>
        /// version
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> VersionUsingPATCHAsyncWithHttpInfo ();
        
        /// <summary>
        /// whoAmI
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of DataResponseUserEntity</returns>
        System.Threading.Tasks.Task<DataResponseUserEntity> WhoAmIUsingGETAsync ();

        /// <summary>
        /// whoAmI
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (DataResponseUserEntity)</returns>
        System.Threading.Tasks.Task<ApiResponse<DataResponseUserEntity>> WhoAmIUsingGETAsyncWithHttpInfo ();
        
        #endregion Asynchronous Operations
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TokenRestControllerApi : ITokenRestControllerApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRestControllerApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TokenRestControllerApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRestControllerApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public TokenRestControllerApi(Configuration configuration = null)
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
        /// checkToken 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>DataResponsestring</returns>
        public DataResponsestring CheckTokenUsingGET ()
        {
             ApiResponse<DataResponsestring> localVarResponse = CheckTokenUsingGETWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// checkToken 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of DataResponsestring</returns>
        public ApiResponse< DataResponsestring > CheckTokenUsingGETWithHttpInfo ()
        {
            
    
            var localVarPath = "/token/check";
    
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
            
            
            
            
            

            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling CheckTokenUsingGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling CheckTokenUsingGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DataResponsestring>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DataResponsestring) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DataResponsestring)));
            
        }

        
        /// <summary>
        /// checkToken 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of DataResponsestring</returns>
        public async System.Threading.Tasks.Task<DataResponsestring> CheckTokenUsingGETAsync ()
        {
             ApiResponse<DataResponsestring> localVarResponse = await CheckTokenUsingGETAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// checkToken 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (DataResponsestring)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DataResponsestring>> CheckTokenUsingGETAsyncWithHttpInfo ()
        {
            
    
            var localVarPath = "/token/check";
    
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
            
            
            
            
            

            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling CheckTokenUsingGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling CheckTokenUsingGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DataResponsestring>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DataResponsestring) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DataResponsestring)));
            
        }
        
        /// <summary>
        /// version 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>string</returns>
        public string VersionUsingPATCH ()
        {
             ApiResponse<string> localVarResponse = VersionUsingPATCHWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// version 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of string</returns>
        public ApiResponse< string > VersionUsingPATCHWithHttpInfo ()
        {
            
    
            var localVarPath = "/token/version";
    
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
            
            
            
            
            

            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling VersionUsingPATCH: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling VersionUsingPATCH: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<string>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (string) Configuration.ApiClient.Deserialize(localVarResponse, typeof(string)));
            
        }

        
        /// <summary>
        /// version 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> VersionUsingPATCHAsync ()
        {
             ApiResponse<string> localVarResponse = await VersionUsingPATCHAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// version 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (string)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<string>> VersionUsingPATCHAsyncWithHttpInfo ()
        {
            
    
            var localVarPath = "/token/version";
    
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
            
            
            
            
            

            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling VersionUsingPATCH: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling VersionUsingPATCH: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<string>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (string) Configuration.ApiClient.Deserialize(localVarResponse, typeof(string)));
            
        }
        
        /// <summary>
        /// whoAmI 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>DataResponseUserEntity</returns>
        public DataResponseUserEntity WhoAmIUsingGET ()
        {
             ApiResponse<DataResponseUserEntity> localVarResponse = WhoAmIUsingGETWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// whoAmI 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of DataResponseUserEntity</returns>
        public ApiResponse< DataResponseUserEntity > WhoAmIUsingGETWithHttpInfo ()
        {
            
    
            var localVarPath = "/token/whoami";
    
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
            
            
            
            
            

            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling WhoAmIUsingGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling WhoAmIUsingGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DataResponseUserEntity>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DataResponseUserEntity) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DataResponseUserEntity)));
            
        }

        
        /// <summary>
        /// whoAmI 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of DataResponseUserEntity</returns>
        public async System.Threading.Tasks.Task<DataResponseUserEntity> WhoAmIUsingGETAsync ()
        {
             ApiResponse<DataResponseUserEntity> localVarResponse = await WhoAmIUsingGETAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// whoAmI 
        /// </summary>
        /// <exception cref="ServerConnection.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (DataResponseUserEntity)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DataResponseUserEntity>> WhoAmIUsingGETAsyncWithHttpInfo ()
        {
            
    
            var localVarPath = "/token/whoami";
    
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
            
            
            
            
            

            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling WhoAmIUsingGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling WhoAmIUsingGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DataResponseUserEntity>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DataResponseUserEntity) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DataResponseUserEntity)));
            
        }
        
    }
    
}
