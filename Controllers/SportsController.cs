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
        public ActionResult<SportReadDto> GetSportByName(string name)
        {
            var sport = _repository.GetSportByName(name);
            if (sport != null)
            {
                return Ok(_mapper.Map<SportReadDto>(sport));
            }
            return NotFound("The sport you are trying to find does not exists! Check the sport list in the right endpoint!");
        }

        //POST api/sports
        [HttpPost]
        public ActionResult<SportReadDto> CreateSport(SportCreateDto sportCreateDto)
        {
            var sportModel = _mapper.Map<Sport>(sportCreateDto);
            if (_repository.GetSportByName(sportModel.Name) == null)
            {
                _repository.CreateSport(sportModel);
                _repository.SaveChanges();

                var sportReadDto = _mapper.Map<SportReadDto>(sportModel);
               
                return CreatedAtRoute(nameof(GetSportByName), new {Name = sportReadDto.Name}, sportReadDto);
            } else 
            {
                return BadRequest("The Sport you are trying to create already exists! Check the sports list by calling the right endpoint!");
            }
        }
        
        //This has problems... but somehow is useless
        //PUT api/sports/{name}
        // [HttpPut("{name}")]
        // public ActionResult UpdateSport(string name, SportUpdateDto sportUpdateDto)
        // {
        //     var existingSport = _repository.GetSportByName(name);
        //     if(existingSport == null)
        //     {
        //         return NotFound("This sport does not exists !");
        //     }

        //     _mapper.Map(sportUpdateDto, existingSport);
        //     _repository.UpdateSport(existingSport);

        //     _repository.SaveChanges();

        //     return NoContent();
        // }
    }
}