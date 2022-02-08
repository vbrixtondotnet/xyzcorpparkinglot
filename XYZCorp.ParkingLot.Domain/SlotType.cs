using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace XYZCorp.ParkingLot.Domain
{
    // Type of Parking Slot (SP,SP,MP)
    public class SlotType : BaseDomain
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
