using AmsterdamSportInc.Dto;
using AmsterdamSportInc.Models;
using AutoMapper;

namespace AmsterdamSportInc.Mappers
{
    public class SportMapper : Profile
    {
        public SportMapper()
        {
            CreateMap<Sport, SportReadDto>();
            CreateMap<SportCreateDto, Sport>();
        }
    }
}