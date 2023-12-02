using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        private static List<Turn> turns = new List<Turn>{
            new Turn { Id = 1, Date = new DateOnly(2023, 12, 1), Hour = new TimeOnly(8, 30), CustomerId=1,BankerId=1 },
            new Turn { Id = 2, Date = new DateOnly(2023, 12, 1), Hour = new TimeOnly(8, 40), CustomerId=2,BankerId=1 } 
        };
        static int index = 2;


        // GET: api/<Turn>
        [HttpGet]
        public IEnumerable<Turn> Get()
        {
            return turns;
        }

        // GET api/<Turn>/5
        [HttpGet("id/{id}")]
        public ActionResult<Turn> Get(int id)
        {
            var turn = turns.FirstOrDefault(t => t.Id == id);

            if (turn == null)
            {
                return NotFound();
            }

            return turn;
        }

        // GET api/<Turn>/5
        [HttpGet("date/{date}")]
        public ActionResult<Turn> GetByDate(DateOnly date)
        {
            var turn = turns.FirstOrDefault(d => d.Date == date);

            if (turn == null)
            {
                return NotFound();
            }

            return turn;
        }

        // POST api/<Turn>
        [HttpPost]
        public void Post([FromBody] Turn newTurn )
        {
            index++;
            turns.Add(new Turn()
            {
                Id = index,
                Date = newTurn.Date,
                Hour = newTurn.Hour,
                CustomerId = newTurn.CustomerId,
                BankerId = newTurn.BankerId
            });
        }

        // PUT api/<Turn>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Turn newTurn)
        {
            Turn turn1 = turns.Find(x => x.Id == id);
            turn1.Date = newTurn.Date; turn1.Hour = newTurn.Hour; turn1.CustomerId = newTurn.CustomerId; turn1.BankerId = newTurn.BankerId;
            turn1 = newTurn;
        }

        // DELETE api/<Turn>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Turn turn = turns.Find(x => x.Id == id);
            turns.Remove(turn);
        }
    }
}
