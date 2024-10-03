using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/reportingStructure")]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IReportingStructureService _reportingStructureService;
        
        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingStructureService reportingStructureService)
        {
            _logger = logger;
            _reportingStructureService = reportingStructureService;
        }

        [HttpGet("{id}", Name = "GetReportingStructureById")]
        public IActionResult GetReportingStructureById(string id)
        {
            _logger.LogDebug($"Received reporting structure get request for `{id}`");
            var rs = _reportingStructureService.GetReportingStructure(id);
            if (rs == null)
                return NotFound();
            return Ok(rs);
        }
    }
}
