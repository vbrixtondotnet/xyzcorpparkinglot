using System;
using XYZCorp.ParkingLot.Domain;

namespace XYZCorp.ParkingLot.DTO
{
    public class SlotDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SlotTypeID { get; set; }
        public int EntryPointID { get; set; }
        public string Status { get; set; }
        public SlotTypeDto SlotType { get; set; }
        public EntryPointDto EntryPoint { get; set; }
    }
}
