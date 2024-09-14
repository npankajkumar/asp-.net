using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using ProductApi.Models;
using ProductApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }// GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var user = User;
            Console.WriteLine("data from token" + user.FindAll(p => true).ToArray()[1].Value);//.FindFirst("Email").Value);
            return _service.GetAllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var result = _service.GetProductById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            if (value == null) {
                return BadRequest();
            }
            if ( _service.AddProduct(value))
            return CreatedAtAction(nameof(Get), new { id = value.Code }, value);

            return BadRequest();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product p)
        {
           if( _service.UpdateProduct(id, p)) 
                return Ok(p);
                return BadRequest();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if( _service.DeleteProduct(id))
                return Ok();
            return BadRequest();    
        }
    }
}
