using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DunmmyBackend.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisposalLocationController : ControllerBase
    {
        [HttpGet("types")]
        public IActionResult GetLocationTypes()
        {
            var disposalLocationTypes = Enum.GetValues<DisposalLocationType>();
            var disposalTypesMap = disposalLocationTypes.Select(t => new { id = (int)t, name = t });
            return Ok(disposalTypesMap);
        }
    }
}
