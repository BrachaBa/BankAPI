using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer> {
            new Customer { Id = 1, Name = "Racheli" },
            new Customer { Id = 2, Name = "Brachi" }
    };
        static int index = 2;


        // GET: api/<Customer>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        // GET api/<Customer>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = customers.FirstOrDefault(b => b.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // POST api/<Customer>
        [HttpPost]
        public void Post([FromBody] Customer newCustomer)
        {
            index++;
            customers.Add(new Customer() { Id = index, Name = newCustomer.Name });
        }

        // PUT api/<Customer>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Customer>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Customer customer = customers.Find(x => x.Id == id);
            customers.Remove(customer);
        }
    }
}
