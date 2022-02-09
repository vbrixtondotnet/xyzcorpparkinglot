using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XYZCorp.ParkingLot.DataStore.Interfaces;

namespace AYZCorp.ParkingLot.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class EntryPointsController : BaseController
    {
        private readonly IEntryPointDataStore entryPointDataStore;
        public EntryPointsController(IEntryPointDataStore entryPointDataStore)
        {
            this.entryPointDataStore = entryPointDataStore;
        }

        [Route("entrypoints")]
        [HttpGet]
        public async Task<IActionResult> GetEntryPoints(int count = 3)
        {
            return await ApiResponse(() =>
            {
                var entryPoints = this.entryPointDataStore.GetEntryPoints(count);
                var response = new
                {
                    Total = entryPoints.Count(),
                    EntryPoints = entryPoints
                };
                return Ok(response);

            });
        }

        [Route("entrypoints/map")]
        [HttpGet]
        public async Task<IActionResult> GetParkingSlotsByMap(string map)
        {
            var maps = Newtonsoft.Json.JsonConvert.DeserializeObject<int[][]>(map);
            return await ApiResponse(() =>
            {
                var parkingSlots = this.entryPointDataStore.GetParkingSlotsByMap(maps);
                var response = new
                {
                    Total = parkingSlots.Count(),
                    EntryPoints = parkingSlots
                };
                return Ok(response);
            });
        }

        [Route("entrypoints/sizes")]
        [HttpGet]
        public async Task<IActionResult> GetParkingSlotsBySize(string sizes)
        {
            var _sizes = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(sizes);
            return await ApiResponse(() =>
            {
                var parkingSlots = this.entryPointDataStore.GetParkingSlotsBySizes(_sizes);
                var response = new
                {
                    Total = parkingSlots.Count(),
                    EntryPoints = parkingSlots
                };
                return Ok(response);
            });
        }
    }
}
