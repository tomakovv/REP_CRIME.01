using AutoMapper;
using Crime.Domain.Entities;
using Crime.Domain.Entities.Enums;
using Crime.Domain.ValueObjects;
using REP_CRIME._01.Common.Dto;
using REP_CRIME._01.Common.Helpers;

namespace Crime.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CrimeEvent, CrimeEventDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(s => nameof(s.Status)))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(s => nameof(s.Type)))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(s => s.Location.ToString()));

            CreateMap<CreateCrimeEventDto, CrimeEvent>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(s => Location.Create(s.City, s.Street, s.ZipCode)))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(s => EnumParser.ParseEnum<MurderEventType>(s.Type)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(s => CrimeStatus.Waiting));

            CreateMap<CreateCrimeEventDto, CrimeEventDto>();
        }
    }
}