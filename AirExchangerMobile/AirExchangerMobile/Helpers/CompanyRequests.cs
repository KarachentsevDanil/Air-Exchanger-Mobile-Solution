using System;
using AirExchangerMobile.Entities;
using AirExchangerMobile.Model;

namespace AirExchangerMobile.Helpers
{
    public class CompanyRequests
    {
        private static string UserUrl = "/api/companies/";

        public static bool Login(Company loginModel)
        {
            try
            {
                HttpClientHelper.PostData(loginModel, string.Concat(UserUrl, "Login"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Register(Company company)
        {
            try
            {
                HttpClientHelper.PostData(company, string.Concat(UserUrl, "Register"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static UserViewModel GetCurrentUser()
        {
            return HttpClientHelper.GetResult<UserViewModel>(string.Concat(UserUrl, "GetCurrentUser"));
        }
    }
}
