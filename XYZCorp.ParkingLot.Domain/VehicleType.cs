using System;
using System.Collections.Generic;
using System.Text;

namespace XYZCorp.ParkingLot.Domain
{
    // Type of Vehicle: small (S), medium (M) and large (L)
    public class VehicleType : BaseDomain
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
