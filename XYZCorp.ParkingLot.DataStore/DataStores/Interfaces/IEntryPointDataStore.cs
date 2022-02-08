using System;
using System.Collections.Generic;
using System.Text;
using XYZCorp.ParkingLot.DTO;

namespace XYZCorp.ParkingLot.DataStore.DataStores.Interfaces
{
    public interface IEntryPointDataStore : IBaseDataStore
    {
        List<EntryPointDto> GetEntryPoints(int count);
        List<EntryPointDto> GetParkingSlotsByMap(int[][] maps);
        List<EntryPointDto> GetParkingSlotsBySizes(int[] sizes);
    }
}
