using System;
using Czat.ServerConnectionAPI.Client;
using Czat.ServerConnectionAPI.Model;
using Czat.ServerConnectionAPI.Api;
using Newtonsoft.Json;

namespace Czat
{
    /// <summary>
    /// Singleton class, which is used when trying to login or register.
    /// It contacts with server and returns proper response in every situation.
    /// You don't need to create object of this class to access it, just use ServerConnectionManager.Instance
    /// </summary>
    class ServerConnectionManager
    {
        private static ServerConnectionManager _instance;

        private ServerConnectionManager() { }

        private TokenDto _loginToken;

        public TokenDto LoginToken { get { return _loginToken; } }

        public static ServerConnectionManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServerConnectionManager();

                return _instance;
            }
        }

        /// <summary>
        /// This method contacts with server when trying to register user and returns response.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ServerResponse RegisterUser(string email, string login, string password)
        {
            UserRestControllerApi api = new UserRestControllerApi();
            UserDto newUser = new UserDto(email, login, password);

            try
            {
                RestResponse serverResponse = api.RegisterUsingPOST1(newUser);
                return ServerResponse.SUCCESS;
            }
            catch (ApiException exception)
            {
                Error error = JsonConvert.DeserializeObject<Error>(exception.ErrorContent);
                return (ServerResponse)error.ID;
            }
        }

        /// <summary>
        /// This method contacts with server when trying to login user and returns response.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ServerResponse LoginUser(string login, string password)
        {
            UserRestControllerApi api = new UserRestControllerApi();
            LoginDto user = new LoginDto(login, password);

            try
            {
                TokenDto token = api.LoginUsingPOST(user);
                _loginToken = token;
                return ServerResponse.SUCCESS;
            }
            catch (ApiException exception)
            {
                Error error = JsonConvert.DeserializeObject<Error>(exception.ErrorContent);
                return (ServerResponse)error.ID;
            }
        }
    }
}
