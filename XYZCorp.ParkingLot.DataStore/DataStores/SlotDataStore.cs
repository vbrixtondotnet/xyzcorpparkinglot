using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZCorp.ParkingLot.BusinessLogic;
using XYZCorp.ParkingLot.BusinessLogic.Interfaces;
using XYZCorp.ParkingLot.DataStore.DataStores.Interfaces;
using XYZCorp.ParkingLot.Domain;
using XYZCorp.ParkingLot.DTO;

namespace XYZCorp.ParkingLot.DataStore.DataStores
{
    public class SlotDataStore : BaseDataStore, ISlotDataStore
    {
        private readonly ISlotBL slotBL;
        public SlotDataStore(SqlDbContext context, IMapper mapper, ISlotBL slotBL) : base(context, mapper) {
            this.slotBL = slotBL;
        }

        public List<SlotDto> GetParkingSlots(int entryPoints)
        {
            var retval = new List<SlotDto>();

            var dbEntryPoints = this.context.EntryPoints.OrderBy(e=> e.ID).Take(entryPoints).ToList();

            dbEntryPoints.ForEach(dbEntryPoint => {
                   var dbParkingSlots = this.context.Slots.Where(p => p.EntryPointID == dbEntryPoint.ID).ToList();
                   dbParkingSlots.ForEach(slot =>
                   {
                       var dbSlotType = this.context.SlotTypes.FirstOrDefault(st => st.ID == slot.ID);

                       var parkingSlotDto = this.mapper.Map<SlotDto>(slot);
                       var entryPoint = this.mapper.Map<EntryPointDto>(dbEntryPoint);
                       entryPoint.Slots = null;

                       parkingSlotDto.Status = slotBL.GetStatus(slot.Status);
                       parkingSlotDto.EntryPoint = entryPoint;
                       parkingSlotDto.SlotType = this.mapper.Map<SlotTypeDto>(dbSlotType);

                       retval.Add(parkingSlotDto);
                   });
            });
            return retval;
        }

        public List<SlotDto> GetParkingSlotsByMap(int[][] maps)
        {
            throw new NotImplementedException();
            //var retval = new List<SlotDto>();

            //// iterate through given maps
            //for(var m = 0; m < maps.Length; m++)
            //{
            //    var map = maps[m];
            //    var entryPoint = this.context.EntryPoints.OrderBy(e => e.ID).Take(maps.Length).ToList()[m];

            //    //iterate through given map distances
            //    for(var distance = 0; distance < maps[m].Length; distance++)
            //    {
            //        var slotId = map[distance];
            //        var dbSlot = this.context.Slots.FirstOrDefault(slot => slot.ID == slotId);

            //    }
            //}

            //return retval;
        }
    }
}
