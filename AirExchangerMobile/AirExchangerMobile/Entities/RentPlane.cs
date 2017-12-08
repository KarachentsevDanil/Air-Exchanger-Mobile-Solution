using Newtonsoft.Json;

namespace AirExchangerMobile.Entities
{
    [JsonObject(IsReference = true)]
    public class RentPlane
    {
        public int PlaneId { get; set; }
        
        public int RentId { get; set; }

        public virtual Plane Plane { get; set; }

        public virtual Rent Rent { get; set; }
    }
}
