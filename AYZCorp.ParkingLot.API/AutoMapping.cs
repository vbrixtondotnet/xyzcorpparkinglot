using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZCorp.ParkingLot.Domain;
using XYZCorp.ParkingLot.DTO;

namespace AYZCorp.ParkingLot.API
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<EntryPoint, EntryPointDto>();
            CreateMap<Slot, SlotDto>();
            CreateMap<SlotType, SlotTypeDto>();
            CreateMap<ParkingRequestDto, Parking>();
            CreateMap<BaseRate, BaseRateDto>();
            CreateMap<SlotRate, SlotRateDto>();
        }
    }
}
