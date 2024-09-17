using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        // GET: api/Buyer
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "John Doe", "Jane Smith", "Mike Johnson" };
        }
    }
}
