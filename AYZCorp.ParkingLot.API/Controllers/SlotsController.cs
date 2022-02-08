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
    public class SlotsController : BaseController
    {
        private readonly ISlotDataStore parkingSlotDataStore;
        public SlotsController(ISlotDataStore parkingSlotDataStore)
        {
            this.parkingSlotDataStore = parkingSlotDataStore;
        }

        [Route("slots")]
        [HttpGet]
        public async Task<IActionResult> GetParkingSlots(int entryPoints = 3)
        {
            return await ApiResponse(() =>
            {
                var parkingSlots = this.parkingSlotDataStore.GetParkingSlots(entryPoints);
                var response = new
                {
                    Total = parkingSlots.Count(),
                    Slots = parkingSlots
                };
                return Ok(response);
            });
        }


    }
}
