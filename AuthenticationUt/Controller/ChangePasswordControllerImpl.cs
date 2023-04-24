using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUt.DAL;
using AuthenticationUt.Domain;

namespace AuthenticationUt.Controller
{
    public class ChangePasswordControllerImpl : ChangePasswordController
    {
        public LoginUser findByUserLoginID(string userName)
        {
            try
            {
                UserLoginDAO userLoginDAO = new UserLoginDAOImpl();

                return userLoginDAO.findByUserLoginID(userName);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public bool checkUserLoginByPassword(LoginUser userLogin, string oldPassword)
        {
            try
            {
                UserLoginDAO userLoginDAO = new UserLoginDAOImpl();

                return userLoginDAO.checkUserLoginByPassword(userLogin, oldPassword);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void updatePasswordByUserLogin(LoginUser userLogin, string password)
        {
            try
            {
                UserLoginDAO userLoginDAO = new UserLoginDAOImpl();

                userLoginDAO.updatePasswordByUserLogin(userLogin, password);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
