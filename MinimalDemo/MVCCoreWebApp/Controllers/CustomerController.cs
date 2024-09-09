using Microsoft.AspNetCore.Mvc;
using MVCCoreWebApp.Models;
using MVCCoreWebApp.Repositories;

namespace MVCCoreWebApp.Controllers
{
    public class CustomerController : Controller
    {

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer c)
        {
            CustomerRepository.Customer.Add(c);

            return RedirectToAction("Index");
            //    return new ContentResult { ContentType = "text/html", 
            //        Content =$"<b>{c.Name} {c.Email}" };
        }
        public IActionResult Index()
        {
            return View(CustomerRepository.Customer);
        }
        public IActionResult Edit(string id)
        {
            return View(CustomerRepository.Customer.FirstOrDefault(c => c.Id == id));
        }
        [HttpPost]
        public IActionResult Edit(string id, Customer c)
        {
            var result = CustomerRepository.Customer.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Name = c.Name;
                result.Email = c.Email;
                result.Mobile = c.Mobile;
                result.Password = c.Password;
            }
            return RedirectToAction("Index");
        }
    }
}
