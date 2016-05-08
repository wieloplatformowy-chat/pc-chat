using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Czat.ServerConnectionAPI.Client;
using Czat.ServerConnectionAPI.Model;
using Czat.ServerConnectionAPI.Api;

namespace Czat
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

        public string RegisterUser(string login, string password)
        {
            UserRestControllerApi api = new UserRestControllerApi();
            UserDto newUser = new UserDto(login, password);

            try
            {
                RestResponse serverResponse = api.RegisterUsingPOST1(newUser);
                return serverResponse.Response;
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

        public string LoginUser(String login, String password)
        {
            UserRestControllerApi api = new UserRestControllerApi();
            LoginDto user = new LoginDto(login, password);

            try
            {
                TokenDto token = api.LoginUsingPOST(user);
                return token.Token;
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
