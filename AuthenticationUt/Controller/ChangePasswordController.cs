using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.Domain;

namespace AuthenticationUt.Controller
{
    public interface ChangePasswordController
    {
        LoginUser findByUserLoginID(string userName);
        bool checkUserLoginByPassword(LoginUser userLogin, string oldPassword);
        void updatePasswordByUserLogin(LoginUser userLogin, string password);
    }
}
