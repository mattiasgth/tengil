using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tengil.DTO;
using Tengil.Service;

namespace Tengil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusValuesController : ControllerBase
    {
        private readonly ILogger<StatusValuesController> _logger;
        private readonly TengilService _service;
        private readonly IMapper _mapper;

        public StatusValuesController(ILogger<StatusValuesController> logger, TengilService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatusValues()
        {
            try
            {
                var rslt = await _service.GetStatusValues();
                return Ok(rslt);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
