using System.Collections.Generic;
using AirExchangerMobile.Entities;

namespace AirExchangerMobile.Model
{
    public class PlaneModelViewModel : PlaneModel
    {
        public IEnumerable<PlaneType> PlaneTypes { get; set; }
    }
}
