using Microsoft.AspNetCore.Mvc;
using RestWithController.Models;
using RestWithController.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWithController.Controller
{
    [Route("api/Godown")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreListRepository _repo;
        public StoresController(IStoreListRepository repo)
        {
            _repo = repo;
        }// GET: api/Store
        [HttpGet]
        public IEnumerable<Store> Get()
        {
            return _repo.GetAllStores();
        }
        // GET api/Store/location/hyderabad
        
        [HttpGet("location/{location}")]
            public List<Store> Get(string location)
            {
                return _repo.GetStoresByLocation(location);
            }
        [HttpGet("{id}")]
        public Store Get(int id)
        {
            return _repo.GetById(id);
        }
        // POST api/<StoresController>
        [HttpPost]
        public void Post([FromBody] Store s)
        {
            _repo.Add(s);
        }
        // PUT api/<StoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Store value)
        {
            _repo.UpdateStore(id, value);
        }
        // DELETE api/<StoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           // ((StoreListRepository)_repo).GetByName("anil");//calling extension method
            _repo.Delete(id);
        }
    }
    public static class  StoreExtension
    {
        public static string GetByName(this StoreListRepository s,string name)
        {
               return name.ToUpper();
        }
    }
}
