using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MISA.WebFresher07.MF1741.TTKIEN.Controllers
{
    [Route("")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        [HttpGet]
        public ActionResult ServerAsync()
        {
            return Ok($"Server is running now {DateTime.Now}");
        } 
    }
}
