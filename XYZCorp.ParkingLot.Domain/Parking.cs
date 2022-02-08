using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace XYZCorp.ParkingLot.Domain
{
    public class Parking : BaseDomain
    {
        public string PlateNo { get; set; }
        [ForeignKey("Slot")]
        public int SlotID { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int Status { get; set; }
        public decimal? AmountPaid { get; set; }

        [JsonIgnore]
        public Slot Slot { get; set; }
    }
}
