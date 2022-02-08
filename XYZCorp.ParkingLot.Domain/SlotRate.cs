using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace XYZCorp.ParkingLot.Domain
{
    // Rate per parking slot
    public class SlotRate : BaseDomain
    {
        [ForeignKey("SlotType")]
        public int SlotTypeID { get; set; }
        public decimal RatePerHour { get; set; }

        [JsonIgnore]
        public SlotType SlotType { get; set; }
    }
}
