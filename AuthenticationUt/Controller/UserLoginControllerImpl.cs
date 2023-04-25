using System;
using AuthenticationUt.DAL;
using AuthenticationUt.Domain;

namespace AuthenticationUt.Controller
{
    public class UserLoginControllerImpl: UserLoginController
    {
        public bool checkUserLoginByPassword(LoginUser uLogin, string password)
        {
            try
            {
                UserLoginDAO userLoginDAO = new UserLoginDAOImpl();

                return userLoginDAO.checkUserLoginByPassword(uLogin, password);

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

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
    }
}
