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
        [HttpGet("Lowcpu/uses-too-many-threadpool-threads-v2")]
        public IActionResult SyncOverAsyncResultV2()
        {
            string val = Task.Run(() => legacyService.DoAsyncOperationWell()).GetAwaiter().GetResult();
            return Ok(val);
        }
        [HttpGet("lowcpu/uses-too-many-threadpool-threads-v3")]
        public IActionResult SyncOverAsyncResultV3()
        {
            string val = Task.Run(() => legacyService.DoAsyncOperationWell().GetAwaiter().GetResult()).GetAwaiter().GetResult();
            return Ok(val);
        }
        /// <returns></returns>
        [HttpGet("Lowcpu/uses-too-many-threadpool-threads-v4")]
        public IActionResult SyncOverAsyncResultV4()
        {
            var task = legacyService.DoAsyncOperationWell();
            task.Wait();
            string val = task.GetAwaiter().GetResult();
            return Ok(val);
        }

        [HttpGet("Lowcpu/uses-too-many-threadpool-threads-fixed")]
        public async Task<IActionResult> SyncOverAsyncResultFixedAsync()
        {
            var result = await legacyService.DoAsyncOperationWell();
            return Ok(result);
        }
    }
}