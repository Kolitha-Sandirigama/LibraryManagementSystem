using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.DAL
{
    public interface UserLoginDAO
    {
        LoginUser findByUserLoginID(string userName);                           // find user by user name
        bool checkUserLoginByPassword(LoginUser ulogin, string password);        // Check user by user name & password
        void addUserLogin(LoginUser user, string loginUserName);                // add new user
        void updatePasswordByUserLogin(LoginUser userLogin, string password);   // update user password
    }
}
