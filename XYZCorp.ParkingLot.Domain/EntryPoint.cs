using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XYZCorp.ParkingLot.Domain
{
    // There are initially three (3) entry points, and can be no less than three (3), leading into the parking complex.
    public class EntryPoint : BaseDomain
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Slot> Slots { get; set; }
    }
}
