using System;
using Czat.ServerConnectionAPI.Client;
using Czat.ServerConnectionAPI.Model;
using Czat.ServerConnectionAPI.Api;
using Newtonsoft.Json;

namespace Czat
{
    //enum represents possible error when trying to login or register
    public enum ServerResponse
    {
        SUCCESS = 0,
        UNKNOWN_ERROR = 1,
        INVALID_JSON = 2,

        USER_NOT_EXISTS = 101,
        INVALID_PASSWORD = 102,
        USERNAME_IS_TAKEN = 103,
        CREDENTIALS_NOT_PROVIDED = 104,
        LOGIN_REQUIRED = 105,
        ALREADY_A_FRIEND = 106,
        NOT_A_FRIEND = 107,

        OTHER_ERROR = 108,
    }

    //this class is used when you try to deserialize json, which represent errors (json is aquired from server)
    public class Error
    {
        public int ID;
        public string Name;
        public string Message;
        public Error(int id, string name, string message)
        {
            this.ID = id;
            this.Name = name;
            this.Message = message;
        }
    }

    //singleton class, which is used when trying to login or register, it contacts with server and 
    //returns proper response in every situation
    //you dont need to create object of this class to access it, just use ServerConnectionManager.Instance
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

        //this method contacts with server when trying to register user and returns response
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


        //this method contacts with server when trying to login user and returns response
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

        public string GetErrorInfo(ServerResponse serverResponse)
        {
            string errorMessage = "";
            switch (serverResponse)
            {           
                case ServerResponse.UNKNOWN_ERROR:
                    errorMessage = "Unknown error occured.";
                    break;
                case ServerResponse.INVALID_JSON:
                    errorMessage = "Invalid JSON in request body.";
                    break;
                case ServerResponse.USER_NOT_EXISTS:
                    errorMessage = "There is no registered user with given name.";
                    break;
                case ServerResponse.INVALID_PASSWORD:
                    errorMessage = "Password does not match.";
                    break;
                case ServerResponse.USERNAME_IS_TAKEN:
                    errorMessage = "UserEntity with given name already exists.";
                    break;
                case ServerResponse.CREDENTIALS_NOT_PROVIDED:
                    errorMessage = "Username or password is null.";
                    break;
                case ServerResponse.LOGIN_REQUIRED:
                    errorMessage = "You are not logged in. Authentication token is invalid, null or expired.";
                    break;
                case ServerResponse.ALREADY_A_FRIEND:
                    errorMessage = "This user has been added as your friend before.";
                    break;
                case ServerResponse.NOT_A_FRIEND:
                    errorMessage = "This user is not your friend.";
                    break;
                default:
                    errorMessage = "Something went wrong";
                    break;
            }
            return errorMessage;
        }
    }
}
