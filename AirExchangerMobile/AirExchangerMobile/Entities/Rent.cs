using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AirExchangerMobile.Entities
{
    [JsonObject(IsReference = true)]
    public class Rent
    {
        public int RentId { get; set; }

        public int CompanyId { get; set; }

        public int CountFlights { get; set; }

        public string Feedback { get; set; }

        public bool IsCompleated { get; set; }

        public virtual Company Company { get; set; }

        public ICollection<RentPlane> Planes { get; set; }

        [JsonIgnore]
        public double? TotalPrice
        {
            get
            {
                var sumOfMoney = Planes.Sum(x => x.Plane.CostPerFlight);
                return sumOfMoney * CountFlights;
            }
        }
    }
}
