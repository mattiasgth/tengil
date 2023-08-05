using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tengil.Service;
using Tengil.Service.DTO;

namespace Tengil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : ControllerBase
    {
        private readonly ILogger<UnitsController> _logger;
        private readonly TengilService _service;
        private readonly IMapper _mapper;

        public UnitsController(ILogger<UnitsController> logger, TengilService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUnits()
        {
            try
            {
                var rslt = await _service.GetUnits();
                return Ok(rslt);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }        
        }
    }
}
