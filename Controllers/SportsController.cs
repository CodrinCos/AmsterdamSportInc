using System.Collections.Generic;
using AmsterdamSportInc.Data;
using AmsterdamSportInc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmsterdamSportInc.Controllers
{
    [Route("api/sports")]
    [ApiController]
    public class SportsController : ControllerBase
    {

        private readonly ISportRepository _repository;

        public SportsController(ISportRepository repository)
{
            _repository = repository;
        }
        //GET api/sports
        [HttpGet]
        public ActionResult<IEnumerable<Sport>> GetAllSports()
        {
            var sports = _repository.GetAllSports();
            return Ok("test");
        }

        //GET api/sports/{name}
        [HttpGet("{name}", Name = "GetSportByName")]
        public ActionResult<Sport> GetSportByName(string name)
        {
            return Ok("test");
        }
    }
}