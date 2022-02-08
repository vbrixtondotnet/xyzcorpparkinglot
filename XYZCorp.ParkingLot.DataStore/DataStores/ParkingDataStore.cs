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
    public class ParkingDataStore : BaseDataStore, IParkingDataStore
    {
        private readonly IParkingBL parkingBL;
        private readonly ISlotBL slotBL;
        public ParkingDataStore(SqlDbContext context, IMapper mapper, IParkingBL parkingBL, ISlotBL slotBL) : base(context, mapper) 
        {
            this.parkingBL = parkingBL;
            this.slotBL = slotBL;
        }

        public async Task<ParkingResponseDto> Park(ParkingRequestDto parkingRequestDto)
        {
            var dbParking = this.mapper.Map<Parking>(parkingRequestDto);
            var result = new ParkingResponseDto();
            Parking existingParking = null;

            //check if selected slot is vacant
            var dbSlot = this.context.Slots.FirstOrDefault(s => s.ID == dbParking.SlotID);
            if (dbSlot.Status == (int)Enums.SlotStatus.Occupied)
            {
                result.State = State.Fail;
                result.Message = Messages.SLOT_ALREADY_OCCUPIED;
                return await Task.Run(() => { return result; });
            }

            // check vehicle by plate number
            existingParking = context.Parkings.FirstOrDefault(p => p.PlateNo == parkingRequestDto.PlateNo && p.Status == (int)Enums.ParkingStatus.Parked);
            if (existingParking != null)
            {
                result.State = State.Fail;
                result.Message = Messages.EXISTING_VEHICLE_PARKED;
                return await Task.Run(() => { return result; });
            }

            // update slot status
            dbSlot.Status = (int)Enums.SlotStatus.Occupied;

            dbParking.Status = (int)Enums.ParkingStatus.Parked;

            // A vehicle leaving the parking complex and returning within one hour must be charged a continuous rate,
            // i.e.the vehicle must be considered as if it did not leave.Otherwise, rates must be implemented as described.
            existingParking = context.Parkings.Where(p => p.PlateNo == parkingRequestDto.PlateNo && p.End != null).OrderByDescending(p => p.Start).FirstOrDefault();
            if(existingParking != null && (int)Math.Round(((DateTime)existingParking.End - existingParking.Start).TotalHours, 1) <= 1)
            {
                dbParking.End = null;
                dbParking.DateModified = DateTime.Now;
            }
            else
            {
                dbParking.Start = DateTime.Now;
                dbParking.DateCreated = DateTime.Now;
                dbParking.CreatedBy = 1;

                this.context.Add(dbParking);
            }

            this.context.SaveChanges();

            var slotDto = mapper.Map<SlotDto>(dbSlot);
            var slotType = context.SlotTypes.FirstOrDefault(st => st.ID == slotDto.SlotTypeID);

            slotDto.SlotType = mapper.Map<SlotTypeDto>(slotType);
            slotDto.Status = slotBL.GetStatus(dbSlot.Status);
            result.ID = dbParking.ID;
            result.End = null;
            result.PlateNo = dbParking.PlateNo;
            result.Start = dbParking.Start;
            result.Slot = slotDto;
            result.Status = parkingBL.GetStatus(dbParking.Status);

            return await Task.Run(() => { return result; });
        }

        public async Task<ParkingPaymentResponseDto> Pay(ParkingPaymentRequestDto parkingPaymentRequestDto)
        {
            var dbParking = context.Parkings.FirstOrDefault(p => p.ID == parkingPaymentRequestDto.ParkingID);
            dbParking.Status = (int)Enums.ParkingStatus.Paid;
            dbParking.AmountPaid = parkingPaymentRequestDto.Amount;

            context.SaveChanges();

            //get slot
            var dbSlot = context.Slots.FirstOrDefault(s => s.ID == dbParking.ID);
            //get slot type
            var dbSlotType = context.SlotTypes.FirstOrDefault(sl => sl.ID == dbSlot.SlotTypeID);
            //get entryPoint
            var dbEntryPoint = context.EntryPoints.FirstOrDefault(e => e.ID == dbSlot.EntryPointID);
            // get base rates

            var slotDto = mapper.Map<SlotDto>(dbSlot);
            slotDto.SlotType = mapper.Map<SlotTypeDto>(dbSlotType);
            slotDto.EntryPoint = mapper.Map<EntryPointDto>(dbEntryPoint);
            slotDto.Status = slotBL.GetStatus(dbSlot.Status);

            var totalHours = parkingBL.CalculateTotalHours(dbParking);
            var excessHours = parkingBL.CalculateExcessHours(dbParking);
            
            return await Task.Run(() =>
            {
                return new ParkingPaymentResponseDto
                {
                    ParkingID = dbParking.ID,
                    AmountPaid = parkingPaymentRequestDto.Amount,
                    PlateNo = dbParking.PlateNo,
                    ExcessHours = excessHours,
                    TotalHours = totalHours,
                    Slot = slotDto,
                    Status = parkingBL.GetStatus(dbParking.Status)
                };
            });


        }

        public async Task<ParkingOutResponseDto> UnPark(ParkingOutRequestDto parkingOutRequestDto)
        {
            var parking = context.Parkings.FirstOrDefault(p => p.ID == parkingOutRequestDto.ParkingID);
            parking.End = DateTime.Now;
            parking.Status = (int)Enums.ParkingStatus.Out;

            //get slot
            var dbSlot = context.Slots.FirstOrDefault(s => s.ID == parking.ID);
            dbSlot.Status = (int)SlotStatus.Vacant;
            context.SaveChanges();

            //get slot type
            var dbSlotType = context.SlotTypes.FirstOrDefault(sl => sl.ID == dbSlot.SlotTypeID);
            //get entryPoint
            var dbEntryPoint = context.EntryPoints.FirstOrDefault(e => e.ID == dbSlot.EntryPointID);
            // get base rates
            var baseRates = context.BaseRates.FirstOrDefault();
            //get slot rates
            var slotRates = context.SlotRates.FirstOrDefault(r => r.SlotTypeID == dbSlot.SlotTypeID);
            

            var totalHours = parkingBL.CalculateTotalHours(parking);
            var excessHours = parkingBL.CalculateExcessHours(parking);
            var chargeableAmount = parkingBL.CalculateParkingCharge(parking, slotRates, baseRates);

            var slotDto = mapper.Map<SlotDto>(dbSlot);
            slotDto.SlotType = mapper.Map<SlotTypeDto>(dbSlotType);
            slotDto.EntryPoint = mapper.Map<EntryPointDto>(dbEntryPoint);
            slotDto.Status = slotBL.GetStatus(dbSlot.Status);


            return await Task.Run(() =>
            {
                return new ParkingOutResponseDto
                {
                    ParkingID = parking.ID,
                    TotalHours = totalHours,
                    ExcessHours = excessHours,
                    TotalAmountPayable = chargeableAmount,
                    End = parking.End,
                    Start = parking.Start,
                    Status = parkingBL.GetStatus(parking.Status),
                    PlateNo = parking.PlateNo,
                    Slot = slotDto,
                    BaseRates = mapper.Map<BaseRateDto>(baseRates),
                    SlotRates = mapper.Map<SlotRateDto>(slotRates)
                };
            });

        }

    }
}
