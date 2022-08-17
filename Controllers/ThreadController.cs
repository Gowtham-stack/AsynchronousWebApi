using AsynchronousWebApi.Processors;
using Microsoft.AspNetCore.Mvc;

namespace AsynchronousWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThreadController : Controller
    {
        [HttpGet("CreateMultipleThreads")]
        public IActionResult Index()
        {
            ThreadProcessor.CreateMultipleThreads();
            return View();
        }

        [HttpGet("GetThreadPoolCount")]
        public IActionResult GetThreadPool()
        {
            int minWorker, minIOC;
            // Get the current settings.
            ThreadPool.GetMinThreads(out minWorker, out minIOC);
            return Ok(new {minWorker, minIOC});
        }
    }
}
