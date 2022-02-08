using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace XYZCorp.ParkingLot.Domain
{
  //(a) S vehicles can park in SP, MP and LP parking spaces;
  //(b) M vehicles can park in MP and LP parking spaces; and
  //(c) L vehicles can park only in LP parking spaces.
    public class VehicleSlotAssignment : BaseDomain
    {
        [ForeignKey("SlotType")]
        public int SlotTypeID { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypeID { get; set; }

        [JsonIgnore]
        public SlotType SlotType { get; set; }
        [JsonIgnore]
        public VehicleType VehicleType { get; set; }
    }
}
