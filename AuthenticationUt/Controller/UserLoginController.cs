using System;
using AuthenticationUt.Domain;

namespace AuthenticationUt.Controller
{
    public interface UserLoginController
    {
        bool checkUserLoginByPassword(LoginUser uLogin, string password);
        LoginUser findByUserLoginID(string userName);
    }
}
