using Microsoft.AspNetCore.Mvc;

namespace Tickets.Controllers
{
    [Route("[controller]/[action]")]
    public class ProcessController : Controller
    {
        [HttpGet]
        public string Sale()
        {
            return "Hello";
        }
    }
}