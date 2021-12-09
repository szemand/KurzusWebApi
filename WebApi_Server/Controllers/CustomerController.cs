using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi_Server.Models;
using WebApi_Server.Repositories;

namespace WebApi_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var customers = CustomerRepository.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(long id)
        {
            var customers = CustomerRepository.GetCustomers().ToList();

            var selectedCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (selectedCustomer != null)
            {
                return Ok(selectedCustomer);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody]Customer customer)
        {
            var customers = CustomerRepository.GetCustomers().ToList();

            customer.Id = GetNewId(customers);
            customer.Status = "Felvett munka";
            customer.DateAdded = DateTime.Now;
            customers.Add(customer);

            CustomerRepository.StoreCustomers(customers);
            return Ok();
        }

        public ActionResult Put([FromBody]Customer customer)
        {
            var customers = CustomerRepository.GetCustomers().ToList();

            var customerToUpdate = customers.FirstOrDefault(c => c.Id == customer.Id);
            if (customerToUpdate != null)
            {
                customerToUpdate.Name = customer.Name;
                customerToUpdate.CarType = customer.CarType;
                customerToUpdate.LicensePlate = customer.LicensePlate;
                customerToUpdate.Description = customer.Description;
                customerToUpdate.Status = customer.Status;

                CustomerRepository.StoreCustomers(customers);
                return Ok();
            }

            return NotFound();
        }

        private long GetNewId(IEnumerable<Customer> customers)
        {
            long newId = 0;
            foreach (var customer in customers)
            {
                if (newId < customer.Id)
                {
                    newId = customer.Id;
                }
            }

            return newId + 1;
        }
    }
}
