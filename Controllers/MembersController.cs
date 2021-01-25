using System.Collections.Generic;
using AmsterdamSportInc.Data;
using AmsterdamSportInc.Dto;
using AmsterdamSportInc.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AmsterdamSportInc.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _repository;

        public MembersController(IMemberRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        //GET api/members
        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetAllMembers()
        {
            var members = _repository.GetAllMembers();
            return Ok(members);
        }


        //GET api/members/{id}
        [HttpGet("{id}", Name = "GetMemberById")]
        public ActionResult<MemberReadDto> GetMemberById(int id)
        {
            var member = _repository.GetMemberById(id);
            if (member != null)
            {
                return Ok(_mapper.Map<MemberReadDto>(member));
            }
            return NotFound("The id that you are trying to find is incorrect!");
        }

        //POST api/members
        [HttpPost]
        public ActionResult<MemberReadDto> CreateMember(MemberCreateDto memberCreateDto)
        {
            var memberModel = _mapper.Map<Member>(memberCreateDto);
            _repository.CreateMember(memberModel);
            _repository.SaveChanges();

            var memberReadDto = _mapper.Map<MemberReadDto>(memberModel);

            return CreatedAtRoute(nameof(GetMemberById), new { Id = memberReadDto.Id }, memberReadDto);

        }

    }
}