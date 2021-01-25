using AmsterdamSportInc.Dto;
using AmsterdamSportInc.Models;
using AutoMapper;

namespace AmsterdamSportInc.Mappers
{
    public class MemberMapper : Profile
    {
        public MemberMapper()
        {
            CreateMap<Member, MemberReadDto>();
            CreateMap<MemberReadDto, Member>();
        }
    }
}