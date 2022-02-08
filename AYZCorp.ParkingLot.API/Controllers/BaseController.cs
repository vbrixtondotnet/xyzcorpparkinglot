using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AYZCorp.ParkingLot.API.Controllers
{
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ApiResponse(Func<IActionResult> method)
        {
            try
            {
                return await Task.Run(() => { return method(); });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => { return BadRequest(ex.Message); });
            }
        }
    }
}
