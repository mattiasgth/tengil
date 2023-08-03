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
    public class CustomersController : ControllerBase
    {

        private readonly ILogger<CustomersController> _logger;
        private readonly TengilService _service;
        private readonly IMapper _mapper;

        public CustomersController(ILogger<CustomersController> logger, TengilService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers(int skip = 0, int take = 50)
        {
            try
            {
                var customers = await _service.GetCustomers(skip, take);
                var rslt = _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
                return Ok(rslt);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }        
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _service.GetCustomerById(id);
            return Ok(customer);
        }
    }
}