using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerConnection.Client;
using ServerConnection.Model;
using ServerConnection.Api;

namespace ServerConnection
{
    class ServerConnectionManager
    {
        private static ServerConnectionManager instance;

        private ServerConnectionManager() { }

        public static ServerConnectionManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServerConnectionManager();

                return instance;
            }
        }

        public dynamic RegisterUser(string login, string password)
        {
            UserRestControllerApi api = new UserRestControllerApi();
            UserDto newUser = new UserDto(login, password);

            try
            {
                BaseResponse serverResponse = api.RegisterUsingPOST(newUser);
                if (serverResponse.Success != null)
                {
                    if ((bool)serverResponse.Success)
                        return serverResponse.Success;
                    else
                        return serverResponse.Error.Message;
                }
                else
                {
                    return serverResponse.Error.Message;
                }
            }
            catch (ApiException exception)
            {
                return exception.GetExceptionInfo();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public String LoginUser(String login, String password)
        {
            UserRestControllerApi api = new UserRestControllerApi();
            UserDto user = new UserDto(login, password);

            try
            {
                DataResponsestring serverResponse = api.LoginUsingPOST(user);
                return "success";

            }
            catch (ApiException exception)
            {
                return exception.GetExceptionInfo();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}
