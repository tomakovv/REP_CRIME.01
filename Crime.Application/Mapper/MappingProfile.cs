using AutoMapper;
using Crime.Domain.Entities;
using REP_CRIME._01.Common.Dto;

namespace Crime.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CrimeEvent, CrimeEventDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(s => nameof(s.Status)))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(s => nameof(s.Type)))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(s => s.Location.ToString())).ReverseMap();
        }
    }
}