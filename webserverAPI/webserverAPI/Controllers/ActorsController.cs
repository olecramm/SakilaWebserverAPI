using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sakila.webserverAPI.Models;

namespace Sakila.webserverAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private SakilaDBContext dbContext;

        public ActorsController()
        {
            string connectionString = "server=localhost;port=3306;database=sakila;userid=root;pwd=d3y9j9j9!;sslmode=none";
            dbContext = SakilaDbContextFactory.Create(connectionString);
        }

        // GET api/actors
        [HttpGet]
        public IActionResult GetAllActors()
        {
            return Ok(dbContext.Actor.ToArray());
        }

        // GET api/actors/101
        [HttpGet("{id}")]
        public IActionResult GetActorsByID(int id)
        {
            var actor = dbContext.Actor.SingleOrDefault(a => a.Actor_ID == id);
            if (actor != null)
            {
                return Ok(actor);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/actors
        [HttpPost]
        public ActionResult InsertActor([FromBody] Actor actor)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            dbContext.Actor.Add(actor);
            dbContext.SaveChanges();
            return Created("api/actors", actor);
        }

        // PUT api/actors/101
        [HttpPut("{id}")]
        public ActionResult UpdateActor([FromBody] Actor actor, int id)
        {
            var target = dbContext.Actor.SingleOrDefault(a => a.Actor_ID == id);

            if (target != null && ModelState.IsValid)
            {
                dbContext.Entry(target).CurrentValues.SetValues(actor);
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/actors/101
        [HttpDelete("{id}")]
        public ActionResult DeleteActorByID(int id)
        {
            var actor = dbContext.Actor.SingleOrDefault(a => a.Actor_ID == id);
            if (actor != null)
            {
                dbContext.Actor.Remove(actor);
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}