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
using XYZCorp.ParkingLot.Utilities;
using static XYZCorp.ParkingLot.Utilities.Enums;

namespace XYZCorp.ParkingLot.DataStore.DataStores
{
    public class EntryPointDataStore : BaseDataStore, IEntryPointDataStore
    {
        private readonly ISlotBL slotBL;
        public EntryPointDataStore(SqlDbContext context, IMapper mapper, ISlotBL slotBL) : base(context, mapper) {
            this.slotBL = slotBL;
        }

        public override List<T> GetAll<T>()
        {
            var retval = new List<EntryPointDto>();
            var entryPoints = this.context.EntryPoints.ToList();

            entryPoints.ForEach(e => {
                EntryPointDto entryPointDto = this.mapper.Map<EntryPointDto>(e);

                // get parking slots
                var parkingSlots = this.context.Slots.Where(ps => ps.EntryPointID == entryPointDto.ID).ToList();

                parkingSlots.ForEach(parkingSlot => {
                    SlotDto parkingSlotDto = this.mapper.Map<SlotDto>(parkingSlot);
                    parkingSlotDto.Status = slotBL.GetStatus(parkingSlot.Status);
                    entryPointDto.Slots.Add(parkingSlotDto);
                });
                retval.Add(entryPointDto);
            });

            return (List<T>)Convert.ChangeType(retval, typeof(List<T>));
        }

        List<EntryPointDto> IEntryPointDataStore.GetEntryPoints(int count)
        {
            var retval = new List<EntryPointDto>();
            var entryPoints = this.context.EntryPoints.OrderBy(e => e.ID).Take(count).ToList();

            entryPoints.ForEach(e => {
                EntryPointDto entryPointDto = this.mapper.Map<EntryPointDto>(e);

                // get parking slots
                var slots = this.context.Slots.Where(ps => ps.EntryPointID == entryPointDto.ID).ToList();

                slots.ForEach(slot => {
                    var slotType = this.context.SlotTypes.FirstOrDefault(st => st.ID == slot.SlotTypeID);

                    SlotDto slotDto = this.mapper.Map<SlotDto>(slot);
                    SlotTypeDto slotTypeDto = this.mapper.Map<SlotTypeDto>(slotType);

                    slotDto.Status = slotBL.GetStatus(slot.Status);
                    slotDto.EntryPoint = null;
                    slotDto.SlotType = slotTypeDto;
                    entryPointDto.Slots.Add(slotDto);
                });
                retval.Add(entryPointDto);
            });

            return retval;
        }

        public List<EntryPointDto> GetParkingSlotsByMap(int[][] maps)
        {
            var retval = new List<EntryPointDto>();

            // iterate through given maps
            for (var m = 0; m < maps.Length; m++)
            {
                var map = maps[m];
                //var entryPoint = this.context.EntryPoints.OrderBy(e => e.ID).Take(maps.Length).ToList()[m];
                //var entryPointDto = this.mapper.Map<EntryPointDto>(entryPoint);

                //iterate through given map distances
                for (var entryPointIndex = 0; entryPointIndex < maps[m].Length; entryPointIndex++)
                {
                    var entryPoint = this.context.EntryPoints.OrderBy(e => e.ID).ToList()[entryPointIndex];
                    var entryPointInList = retval.Find(e => e.ID == entryPoint.ID);

                    var entryPointDto = entryPointInList != null ? entryPointInList : this.mapper.Map<EntryPointDto>(entryPoint);

                    var slotId = map[entryPointIndex];
                    var dbSlot = this.context.Slots.FirstOrDefault(slot => slot.ID == slotId && slot.EntryPointID == entryPoint.ID);
                    if (dbSlot != null)
                    {
                        //slot type
                        var dbSlotType = this.context.SlotTypes.FirstOrDefault(sl => sl.ID == dbSlot.SlotTypeID);

                        var slotDto = this.mapper.Map<SlotDto>(dbSlot);

                        slotDto.Status = slotBL.GetStatus(dbSlot.Status);
                        slotDto.EntryPoint = null;
                        slotDto.SlotType = this.mapper.Map<SlotTypeDto>(dbSlotType);

                        entryPointDto.Slots.Add(slotDto);
                    }

                    if(entryPointInList == null) retval.Add(entryPointDto);
                }
            }

            return retval;
        }

        public List<EntryPointDto> GetParkingSlotsBySizes(int[] sizes)
        {
            var retval = new List<EntryPointDto>();

            var dbEntryPoints = this.context.EntryPoints.ToList();

            foreach (var dbEntryPoint in dbEntryPoints)
            {
                var entryPointDto = this.mapper.Map<EntryPointDto>(dbEntryPoint);
                // iterate through given sizes
                for (var s = 0; s < sizes.Length; s++)
                {
                    var size = (int)((SlotSize)sizes[s]) + 1;

                    var dbSlot = this.context.Slots.FirstOrDefault(slot => slot.EntryPointID == dbEntryPoint.ID && slot.SlotTypeID == size);
                    if (dbSlot != null)
                    {
                        //slot type
                        var dbSlotType = this.context.SlotTypes.FirstOrDefault(sl => sl.ID == dbSlot.SlotTypeID);

                        var slotDto = this.mapper.Map<SlotDto>(dbSlot);

                        slotDto.Status = slotBL.GetStatus(dbSlot.Status);
                        slotDto.EntryPoint = null;
                        slotDto.SlotType = this.mapper.Map<SlotTypeDto>(dbSlotType);

                        entryPointDto.Slots.Add(slotDto);
                    }
                }

                retval.Add(entryPointDto);
            }

            return retval;
        }
    }
}
