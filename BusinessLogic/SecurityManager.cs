using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessObjects;

namespace BusinessLogic
{
    public class SecurityManager
    {
        const int MIN_USERNAME = 5;
        const int MIN_PASSWORD = 5;
        public static AccessToken ValidateExistingUser(string username, string password)
        {
            AccessToken accessToken;

            if (username.Length < MIN_USERNAME || password.Length < MIN_PASSWORD)
            {
                throw new ApplicationException("Invalid username or password.");
            }

            try
            {
                if (1 == CookAccessor.FindUserByUsernameAndPassword(username, password.HashSha256()))
                {
                    var cook = CookAccessor.RetrieveUserByUsername(username);
                    var roles = CookAccessor.RetrieveRolesByCookID(cook.CookID);
                    accessToken = new AccessToken(cook, roles);
                }
                else
                {
                    throw new ApplicationException("Data not found - could not find user by username and password.");
                }
            }
            catch
            {
                throw;
            }
            return accessToken;
        }

        public static AccessToken ValidateNewUser(string username, string newPassword)
        {
            // check for new user
            if (1 == CookAccessor.FindUserByUsernameAndPassword(username, "password".HashSha256()))
            {
                CookAccessor.SetPasswordForUsername(username, "password".HashSha256(), newPassword.HashSha256());
            }
            else
            {
                throw new ApplicationException("Data not found.");
            }

            return ValidateExistingUser(username, newPassword);
        }

    }
}
