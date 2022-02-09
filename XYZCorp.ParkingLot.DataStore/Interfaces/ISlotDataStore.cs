using System;
using System.Collections.Generic;
using System.Text;
using XYZCorp.ParkingLot.DTO;

namespace XYZCorp.ParkingLot.DataStore.Interfaces
{
    public interface ISlotDataStore : IBaseDataStore
    {
        List<SlotDto> GetParkingSlots(int entryPoints);
        List<SlotDto> GetParkingSlotsByMap(int[][] maps);
    }
}
