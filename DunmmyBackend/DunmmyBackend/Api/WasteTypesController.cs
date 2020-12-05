using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DunmmyBackend.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WasteTypesController : ControllerBase
    {
        [HttpGet()]
        public IActionResult GetTypes()
        {
            var wasteTypes = Enum.GetValues<WasteType>();
            var wasteTypeMap = wasteTypes.Select(t => new { id = (int)t, name = t });

            return Ok(wasteTypeMap);
        }
    }
}
