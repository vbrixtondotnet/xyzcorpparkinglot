using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace XYZCorp.ParkingLot.Domain
{
    public class Slot : BaseDomain
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("SlotType")]
        public int SlotTypeID { get; set; }
        [ForeignKey("EntryPoint")]
        public int EntryPointID { get; set; }

        public int Status { get; set; }

        [JsonIgnore]
        public SlotType SlotType { get; set; }
        [JsonIgnore]
        public EntryPoint EntryPoint { get; set; }
    }
}
