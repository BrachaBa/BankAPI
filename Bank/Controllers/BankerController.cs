using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankerController : ControllerBase
    {
        private static List<Banker> bankers = new List<Banker> {
            new Banker { Id = 1, Name = "Avi" },
            new Banker { Id = 2, Name = "Moshe" }};
        static int index = 2;
        // GET: api/<Banker>d
        [HttpGet]
        public IEnumerable<Banker> Get()
        {
            return bankers;
        }

        // GET api/<Banker>/5
        [HttpGet("id/{id}")]
        public ActionResult<Banker> Get(int id)
        {
            var banker = bankers.FirstOrDefault(b => b.Id == id);

            if (banker == null)
            {
                return NotFound();
            }

            return banker;
        }

        // GET api/<Banker>/5
        [HttpGet("name/{name}")]
        public ActionResult<Banker> GetByName(string name)
        {
            var banker = bankers.FirstOrDefault(b => b.Name == name);

            if (banker == null)
            {
                return NotFound();
            }

            return banker;
        }

        // POST api/<Banker>
        [HttpPost]
        public void Post([FromBody] Banker newBanker)
        {
            index++;
            bankers.Add(new Banker() { Id = index, Name = newBanker.Name });
        }

        // PUT api/<Banker>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Banker newBanker)
        {
            Banker banker1 = bankers.Find(x => x.Id == id);
            banker1.Name = newBanker.Name;
            banker1 = newBanker;
        }

        //    // DELETE api/<Banker>/5
        //    [HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    Banker banker = bankers.Find(x => x.Id == id);
        //    bankers.Remove(banker);
        //    //for (int i = banker.Id; i < bankers.Count+1; i++)
        //    //{
        //    //    bankers[i].Id = bankers[i].Id - 1;
        //    //}
        //}

        // DELETE api/<BankayController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var banker = bankers.FirstOrDefault(b => b.Id == id);
            bankers.Remove(banker);

            // עדכון ה-IDs של הפריטים הבאים ברשימה
            for (int i = bankers.FindIndex(b => b.Id == id) + 1; i < bankers.Count; i++)
            {
                bankers[i].Id--;
            }
            index--;
        }
    }
}
