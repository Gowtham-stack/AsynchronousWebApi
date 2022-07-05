using AsynchronousWebApi.Processors;
using Microsoft.AspNetCore.Mvc;

namespace AsynchronousWebApi.Controllers
{
    [ApiController]
    public class BadProgramController : Controller
    {
        private readonly LegacyService legacyService;

        public BadProgramController(LegacyService legacyService)
        {
            this.legacyService = legacyService;
        }
        [HttpGet("Hi")]
        public IActionResult SyncOverAsyncResultV1()
        {
            string val = legacyService.DoAsyncOperationWell().Result;
            return Ok(val);
        }
    }
}