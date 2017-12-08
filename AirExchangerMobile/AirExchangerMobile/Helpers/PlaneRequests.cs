using System;
using System.Collections.Generic;
using AirExchangerMobile.Entities;
using AirExchangerMobile.Model;

namespace AirExchangerMobile.Helpers
{
    public class PlaneRequests
    {
        public const string PlaneUrl = "/api/planes/";

        public static bool AddPlane(PlaneViewModel plane)
        {
            try
            {
                HttpClientHelper.PostData(plane, string.Concat(PlaneUrl, "AddPlane"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddPlaneModel(PlaneModel planeModel)
        {
            try
            {
                HttpClientHelper.PostData(planeModel, string.Concat(PlaneUrl, "AddPlaneModel"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<PlaneType> GetPlaneTypes()
        {
            return HttpClientHelper.GetResult<List<PlaneType>>(string.Concat(PlaneUrl, "GetPlaneTypes"));
        }

        public static List<PlaneModel> GetPlaneModels()
        {
            return HttpClientHelper.GetResult<List<PlaneModel>>(string.Concat(PlaneUrl, "GetPlaneModels"));
        }

        public static Plane GetPlaneById(int planeId)
        {
            return HttpClientHelper.GetResult<Plane>(string.Concat(PlaneUrl, $"GetPlaneById?planeId={planeId}"));
        }

        public static List<Plane> GetPlanesOfCompany(int companyId)
        {
            return HttpClientHelper.GetResult<List<Plane>>(string.Concat(PlaneUrl, $"GetPlanesOfCompany?companyId={companyId}"));
        }

        public static List<Plane> GetAvailablePlanes(PlaneViewModel model)
        {
            return HttpClientHelper.PostDataAndGetResult<PlaneViewModel, List<Plane>>(model, string.Concat(PlaneUrl, "GetAvailablePlanes"));
        }
    }
}
