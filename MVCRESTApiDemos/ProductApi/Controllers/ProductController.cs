using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly ProductService _service = new ProductService();

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _service.GetAllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _service.GetProductById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
           if( _service.AddProduct(value))
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);

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
