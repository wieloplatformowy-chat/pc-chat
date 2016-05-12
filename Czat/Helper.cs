using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czat
{
    class Helper
    {
        /// <summary>
        /// Returns text information about error based on response from server.
        /// </summary>
        /// <param name="serverResponse"></param>
        /// <returns></returns>
        public static string GetErrorInfo(ServerResponse serverResponse)
        {
            switch (serverResponse)
            {
                case ServerResponse.UNKNOWN_ERROR:
                    return "Unknown error occured.";
                case ServerResponse.INVALID_JSON:
                    return "Invalid JSON in request body.";
                case ServerResponse.USER_NOT_EXISTS:
                    return "There is no registered user with given name.";
                case ServerResponse.INVALID_PASSWORD:
                    return "Password does not match.";
                case ServerResponse.USERNAME_IS_TAKEN:
                    return "UserEntity with given name already exists.";
                case ServerResponse.CREDENTIALS_NOT_PROVIDED:
                    return "Username or password is null.";
                case ServerResponse.LOGIN_REQUIRED:
                    return "You are not logged in. Authentication token is invalid, null or expired.";
                case ServerResponse.ALREADY_A_FRIEND:
                    return "This user has been added as your friend before.";
                case ServerResponse.NOT_A_FRIEND:
                    return "This user is not your friend.";
                default:
                    return "Something went wrong";
            }
        }
    }
}
