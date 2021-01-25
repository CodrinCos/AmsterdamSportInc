using AmsterdamSportInc.Data;
using AmsterdamSportInc.Dto;
using AmsterdamSportInc.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AmsterdamSportInc.Controllers
{
    [Route("api/membertosport")]
    [ApiController]
    public class MemberToSportController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMemberToSportRepository _repository;

        public MemberToSportController(IMemberToSportRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        //POST apo/memberstosport
        [HttpPost]
        public ActionResult<MemberToSportReadDto> AssignMemberToSport(MemberToSportCreateDto memberToSportDto)
        {
            var memberToSportModel = _mapper.Map<MemberToSport>(memberToSportDto);
            if (!_repository.CheckForDuplicaion(memberToSportModel.MemberId, memberToSportModel.SportName))
            {
                _repository.AssignMemberToSport(memberToSportModel);
                _repository.SaveChanges();
                return Ok(memberToSportModel.SportName + " was assigned succefully!");
            }
            return BadRequest("This person is already assigned!");



        }

    }
}