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
        //POST api/memberstosport
        [HttpPost]
        public ActionResult<MemberToSportReadDto> AssignMemberToSport(MemberToSportCreateDto memberToSportDto)
        {
            var memberToSportModel = _mapper.Map<MemberToSport>(memberToSportDto);
            if (!_repository.CheckForDuplicaion(memberToSportModel.MemberId, memberToSportModel.SportName))
            {
                if(!_repository.CheckIfSportExists(memberToSportModel.SportName))
                {
                    return BadRequest("The sport you are trying to assign is not available!");
                }
                if(!_repository.CheckIfPersonExists(memberToSportModel.MemberId))
                {
                    return BadRequest("The member you are trying to assign is not available!");
                }
                if (memberToSportDto.SportName == "Football" && !_repository.CheckIfFootballAllowed(memberToSportDto.MemberId))
                {
                    return BadRequest("When you assign football you cannot have more than 1 sport already assigned! Please remove a sport for this person!");
                }
                _repository.AssignMemberToSport(memberToSportModel);
                _repository.SaveChanges();
                return Ok(memberToSportModel.SportName + " was assigned succefully!");
            }
            return BadRequest("This person is already assigned!");
        }
    }
}