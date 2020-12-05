using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DunmmyBackend.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisposalLocationController : ControllerBase
    {
        [HttpGet("types")]
        public IActionResult GetLocationTypes()
        {
            return Ok(Enum.GetValues<DisposalLocationType>());
        }
    }
}
