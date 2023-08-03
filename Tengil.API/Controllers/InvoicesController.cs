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
    public class InvoicesController : ControllerBase
    {

        private readonly ILogger<InvoicesController> _logger;
        private readonly TengilService _service;
        private readonly IMapper _mapper;

        public InvoicesController(ILogger<InvoicesController> logger, TengilService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices(int skip = 0, int take = 50)
        {
            var invoices = await _service.GetInvoices(skip, take);
            var rslt = _mapper.Map<IEnumerable<InvoiceListingResponseDTO>>(invoices);
            return Ok(rslt);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            try
            {
                var invoice = await _service.GetInvoiceById(id);
                if(invoice == null)
                {
                    return NotFound();
                }
                var rslt = _mapper.Map<InvoiceResponseDTO>(invoice);
                return Ok(rslt);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateInvoice(int id, InvoiceRequestDTO dto)
        {
            TngInvoice? invoice = await _service.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            var rslt = await _service.InsertOrUpdateInvoice(invoice, dto);
            return Ok(rslt);
        }
    }
}