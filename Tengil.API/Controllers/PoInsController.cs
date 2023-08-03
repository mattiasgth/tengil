using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tengil.DTO;
using Tengil.Service;
using Tengil.Service.DTO;
using tngcmd.Data;

namespace Tengil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoInsController : ControllerBase
    {

        private readonly ILogger<PoInsController> _logger;
        private readonly TengilService _service;
        private readonly IMapper _mapper;

        public PoInsController(ILogger<PoInsController> logger, TengilService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPoIns(int skip = 0, int take = 50)
        {
            try
            {
                var poIns = await _service.GetPoIns(skip, take);
                var rslt = _mapper.Map<IEnumerable<PoInListingResponseDTO>>(poIns);
                return Ok(rslt);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }        
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPoInById(int id)
        {
            var poIn = await _service.GetPoInById(id);
            var rslt = _mapper.Map<PoInResponseDTO>(poIn);
            return Ok(rslt);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePoIn(int id, PoInRequestDTO dto)
        {
            TngPoIn? poIn = await _service.GetPoInById(id);
            if (poIn == null)
            {
                return NotFound();
            }
            var rslt = await _service.InsertOrUpdatePoIn(poIn, dto);
            return Ok(rslt);
        }
    }
}