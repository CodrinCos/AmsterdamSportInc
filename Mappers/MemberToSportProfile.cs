using AmsterdamSportInc.Dto;
using AmsterdamSportInc.Models;
using AutoMapper;

namespace AmsterdamSportInc.Mappers
{
    public class MemberToSportMapper : Profile
    {
        public MemberToSportMapper()
        {
            CreateMap<MemberToSport, MemberToSportReadDto>();
            CreateMap<MemberToSportCreateDto, MemberToSport>();
        }
    }
}