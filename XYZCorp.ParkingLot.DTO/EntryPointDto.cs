using System;
using System.Collections.Generic;
using System.Text;
using XYZCorp.ParkingLot.Domain;

namespace XYZCorp.ParkingLot.DTO
{
    public class EntryPointDto
    {
        public EntryPointDto()
        {
            this.Slots = new List<SlotDto>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public List<SlotDto> Slots { get; set; }
    }
}
