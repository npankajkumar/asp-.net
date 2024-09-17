using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SellerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Seller Service";
        }
    }
}
