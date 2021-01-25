using System.Collections.Generic;
using AmsterdamSportInc.Data;
using AmsterdamSportInc.Dto;
using AmsterdamSportInc.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AmsterdamSportInc.Controllers
{
    [Route("api/sports")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ISportRepository _repository;
        private readonly IMapper _mapper;

        public SportsController(ISportRepository repository, IMapper mapper)
{
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/sports
        [HttpGet]
        public ActionResult<IEnumerable<SportReadDto>> GetAllSports()
        {
            var sports = _repository.GetAllSports();
            return Ok(_mapper.Map<IEnumerable<SportReadDto>>(sports));
        }

        //GET api/sports/{name}
        [HttpGet("{name}", Name = "GetSportByName")]
        public ActionResult<SportReadDto> GetSportByName(string sportName)
        {
            var sport = _repository.GetSportByName(sportName);
            if (sport != null)
            {
                return Ok(_mapper.Map<SportReadDto>(sport));
            }
            return NotFound();
        }
    }
}