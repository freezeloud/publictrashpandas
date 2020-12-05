using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DunmmyBackend.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisposalLocationController : ControllerBase
    {
        private IDataProvider _data;

        public DisposalLocationController(IDataProvider data)
        {
            _data = data;
        }

        [HttpGet("types")]
        public IActionResult GetLocationTypes()
        {
            var disposalLocationTypes = Enum.GetValues<DisposalLocationType>();
            var disposalTypesMap = disposalLocationTypes.Select(t => new { id = (int)t, name = t });
            return Ok(disposalTypesMap);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationDetail(long id)
        {
            var detail = await _data.GetDisposalLocationDetailsAsync(id);
            return Ok(detail);
        }
    }
}
