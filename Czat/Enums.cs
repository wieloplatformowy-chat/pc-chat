using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czat
{
    /// <summary>
    /// Enum represents possible errors when trying to login or register.
    /// </summary>
    public enum ServerResponse
    {
        /// <summary>
        /// Successful action.
        /// </summary>
        SUCCESS = 0,

        /// <summary>
        /// Unknown error occured.
        /// </summary>
        UNKNOWN_ERROR = 1,

        /// <summary>
        /// Invalid JSON in request body.
        /// </summary>
        INVALID_JSON = 2,

        /// <summary>
        /// There is no registered user with given name.
        /// </summary>
        USER_NOT_EXISTS = 101,

        /// <summary>
        /// Password does not match.
        /// </summary>
        INVALID_PASSWORD = 102,

        /// <summary>
        /// UserEntity with given name already exists.
        /// </summary>
        USERNAME_IS_TAKEN = 103,

        /// <summary>
        /// Username or password is null.
        /// </summary>
        CREDENTIALS_NOT_PROVIDED = 104,

        /// <summary>
        /// You are not logged in. Authentication token is invalid, null or expired.
        /// </summary>
        LOGIN_REQUIRED = 105,

        /// <summary>
        /// This user has been added as your friend before.
        /// </summary>
        ALREADY_A_FRIEND = 106,

        /// <summary>
        /// This user is not your friend.
        /// </summary>
        NOT_A_FRIEND = 107,

        /// <summary>
        /// Something went wrong.
        /// </summary>
        OTHER_ERROR = 108,
    }

}
