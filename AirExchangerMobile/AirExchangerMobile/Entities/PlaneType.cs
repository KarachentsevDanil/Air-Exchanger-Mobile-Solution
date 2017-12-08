using Newtonsoft.Json;

namespace AirExchangerMobile.Entities
{
    [JsonObject(IsReference = true)]
    public class PlaneType
    {
        public int PlaneTypeId { get; set; }

        public string Name { get; set; }
    }
}
