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
    public class AssignmentsController : ControllerBase
    {

        private readonly ILogger<AssignmentsController> _logger;
        private readonly TengilService _service;
        private readonly IMapper _mapper;

        public AssignmentsController(ILogger<AssignmentsController> logger, TengilService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignments(int skip = 0, int take = 50)
        {
            try
            {
                _logger.LogDebug($"Entering GetAssignments({skip}, {take})");
                var assignments = await _service.GetAssignments(skip, take);
                var rslt = _mapper.Map<IEnumerable<AssignmentListingResponseDTO>>(assignments);
                return Ok(rslt);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAssignmentById(int id)
        {
            try
            {
                var assignment = await _service.GetAssignmentById(id);
                if (assignment == null)
                {
                    return NotFound();
                }
                var rslt = _mapper.Map<AssignmentResponseDTO>(assignment);
                return Ok(rslt);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }        
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAssignment(int id, AssignmentRequestDTO dto)
        {
            TngAssignment? assignment = await _service.GetAssignmentById(id);
            if (assignment == null)
            {
                return NotFound();
            }
            var rslt = await _service.InsertOrUpdateAssignment(assignment, dto);
            return Ok(rslt);
        }
    }
}