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
        private readonly IMemberRepository _memberRepository;
        private readonly IMemberToSportRepository _memberToSportRepository;

        public MembersController(IMemberRepository memberRepository, IMemberToSportRepository memberToSportRepository, IMapper mapper)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
            _memberToSportRepository = memberToSportRepository;
        }
        //GET api/members
        [HttpGet]
        public ActionResult<IEnumerable<MemberReadDto>> GetAllMembers()
        {
            var members = _memberRepository.GetAllMembers();
            var membersReadDto = _mapper.Map<IEnumerable<MemberReadDto>>(members);
            foreach (var member in membersReadDto)
            {
                var sports = _memberToSportRepository.GetSportsForAMember(member.Id);
                if (sports != null)
                {
                    List<SportReadDto> sportsToRead = new List<SportReadDto>();
                    foreach (var item in sports)
                    {
                        SportReadDto aux = new SportReadDto();
                        aux.Name = item.SportName;
                        sportsToRead.Add(aux);
                    }
                    member.Sports = sportsToRead;
                }

            }
            return Ok(membersReadDto);
        }


        //GET api/members/{id}
        [HttpGet("{id}", Name = "GetMemberById")]
        public ActionResult<MemberReadDto> GetMemberById(int id)
        {
            var member = _memberRepository.GetMemberById(id);
            if (member != null)
            {
                var sports = _memberToSportRepository.GetSportsForAMember(id);
                var memberReadDto = _mapper.Map<MemberReadDto>(member);
                if (sports != null)
                {
                    List<SportReadDto> sportsToRead = new List<SportReadDto>();
                    foreach (var item in sports)
                    {
                        SportReadDto aux = new SportReadDto();
                        aux.Name = item.SportName;
                        sportsToRead.Add(aux);
                        memberReadDto.Sports = sportsToRead;
                    }
                }
                return Ok(memberReadDto);
            }
            return NotFound("The id that you are trying to find is incorrect!");
        }

        //POST api/members
        [HttpPost]
        public ActionResult<MemberReadDto> CreateMember(MemberCreateDto memberCreateDto)
        {
            var memberModel = _mapper.Map<Member>(memberCreateDto);
            _memberRepository.CreateMember(memberModel);
            _memberRepository.SaveChanges();

            var memberReadDto = _mapper.Map<MemberReadDto>(memberModel);

            return CreatedAtRoute(nameof(GetMemberById), new { Id = memberReadDto.Id }, memberReadDto);

        }

    }
}