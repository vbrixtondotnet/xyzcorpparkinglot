using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XYZCorp.ParkingLot.DTO;

namespace XYZCorp.ParkingLot.DataStore.Interfaces
{
    public interface IParkingDataStore : IBaseDataStore
    {
        Task<ParkingResponseDto> Park(ParkingRequestDto parkingRequestDto);
        Task<ParkingOutResponseDto> UnPark(ParkingOutRequestDto parkingOutRequestDto);
        Task<ParkingPaymentResponseDto> Pay(ParkingPaymentRequestDto parkingPaymentRequestDto);
    }
}
