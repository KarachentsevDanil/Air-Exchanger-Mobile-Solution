using System;
using System.Collections.Generic;
using AirExchangerMobile.Entities;

namespace AirExchangerMobile.Helpers
{
    public class RentRequest
    {
        public const string RentUrl = "/api/rents/";

        public static bool AddRent(Rent rent)
        {
            try
            {
                HttpClientHelper.PostData(rent, string.Concat(RentUrl, "AddRent"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CompleteRent(Rent rent)
        {
            try
            {
                HttpClientHelper.PostData(rent, string.Concat(RentUrl, "CompleteRent"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Rent GetRentDetailsById(int rentId)
        {
            return HttpClientHelper.GetResult<Rent>(string.Concat(RentUrl, $"GetRentDetailsById?rentId={rentId}"));
        }

        public static List<Rent> GetRentsOfCompany(int companyId)
        {
            return HttpClientHelper.GetResult<List<Rent>>(string.Concat(RentUrl, $"GetRentsOfCompany?companyId={companyId}"));
        }
    }
}
