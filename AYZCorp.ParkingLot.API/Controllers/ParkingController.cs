using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZCorp.ParkingLot.DataStore.DataStores;
using XYZCorp.ParkingLot.DataStore.DataStores.Interfaces;
using XYZCorp.ParkingLot.DTO;

namespace AYZCorp.ParkingLot.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ParkingController : BaseController
    {
        private readonly IParkingDataStore parkingDataStore;
        public ParkingController(IParkingDataStore parkingDataStore)
        {
            this.parkingDataStore = parkingDataStore;
        }

        [Route("parking")]
        [HttpPost]
        public async Task<IActionResult> Park(ParkingRequestDto parkingDto)
        {
            return await ApiResponse(() =>
            {
                var parkingDtoResponse = this.parkingDataStore.Park(parkingDto).Result;
                if(parkingDtoResponse.State == XYZCorp.ParkingLot.Utilities.Enums.State.Fail)
                {
                    return BadRequest(parkingDtoResponse.Message);
                }

                return Ok(parkingDtoResponse);
            });
        }

        [Route("parking")]
        [HttpPatch]
        public async Task<IActionResult> Unpark(ParkingOutRequestDto parkingOutRequestDto)
        {
            return await ApiResponse(() =>
            {
                var parkingDtoResponse = this.parkingDataStore.UnPark(parkingOutRequestDto).Result;

                return Ok(parkingDtoResponse);
            });
        }

        [Route("parking/pay")]
        [HttpPatch]
        public async Task<IActionResult> Pay(ParkingPaymentRequestDto parkingPaymentRequestDto)
        {
            return await ApiResponse(() =>
            {
                var parkingDtoResponse = this.parkingDataStore.Pay(parkingPaymentRequestDto).Result;

                return Ok(parkingDtoResponse);
            });
        }


    }
}
