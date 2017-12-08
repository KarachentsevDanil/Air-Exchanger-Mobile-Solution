using System.Collections.Generic;
using AirExchangerMobile.Entities;

namespace AirExchangerMobile.Model
{
    public class PlaneViewModel : Plane
    {
        public int CountPlanes { get; set; }

        public int StartCountPlaces { get; set; }

        public int EndCountPlaces { get; set; }

        public IEnumerable<PlaneModel> PlaneModels { get; set; }
    }
}
