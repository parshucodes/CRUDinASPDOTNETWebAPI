using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using Practice.Repository;
using Serilog;
using Serilog.Events;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargerController : ControllerBase
    {
        private readonly IChargerRepo repo;
        private readonly ILogger<ChargerController> logger;
        public ChargerController(IChargerRepo _repo, ILogger<ChargerController> logger)
        {
            this.repo = _repo;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllcharger()
        {
            var chargerd =  repo.GetAll();
            Log.Information("Charger info:{@chargerd}", chargerd);
            if (chargerd == null) { return NotFound(); }
            return Ok(chargerd);
            


        }
        [HttpGet("{id}")]
        public IActionResult Getcharger(int id)
        {
            var singlecharger = repo.GetById(id);
            if (singlecharger == null) { return BadRequest(); }
            return Ok(singlecharger);
        }
        [HttpPost]
        public IActionResult CreateCharge([FromBody]Charger charger)
        {
            repo.CreateCharger(charger);
            return CreatedAtAction(nameof(Getcharger), new { id = charger.Id }, charger);
        }

        [HttpPut("{id}")]
        public IActionResult updatecharger(int id, [FromBody]Charger charger)
        {
            var result = repo.UpdateCharger(charger, id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletecharger(int id)
        {
            repo.DeleteCharger(id);
            return Ok();
        }
    }
}
