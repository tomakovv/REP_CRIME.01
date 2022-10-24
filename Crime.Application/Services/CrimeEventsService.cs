using AutoMapper;
using Crime.Application.Interfaces;
using Crime.Application.Services.Interfaces;
using Crime.Domain.Entities;
using REP_CRIME._01.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crime.Application.Services
{
    public class CrimeEventsService : ICrimeEventsService
    {
        private readonly ICrimeEventsRepository _repository;
        private readonly IMapper _mapper;

        public CrimeEventsService(ICrimeEventsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CrimeEventDto>> GetAllCrimeEventsAsync()
        {
            var crimeEvents = await _repository.GetCrimeEventsAsync();
            var mappedCrimeEvents = _mapper.Map<IEnumerable<CrimeEventDto>>(crimeEvents);
            if (mappedCrimeEvents == null)
                throw new Exception("Crime events not found");
            return mappedCrimeEvents;
        }

        public async Task<CrimeEventDto> GetCrimeEventAsync(string objectId)
        {
            var crimeEvent = await _repository.GetCrimeEventAsync(objectId);
            var mappedCrimeEvent = _mapper.Map<CrimeEventDto>(crimeEvent);
            if (mappedCrimeEvent == null)
                throw new Exception("Crime event not found");
            return mappedCrimeEvent;
        }

        public async Task CreateNewCrimeEventAsync(CreateCrimeEventDto newCrimeEventDto)
        {
            var newCrimeEvent = _mapper.Map<CrimeEvent>(newCrimeEventDto);
            var ev = newCrimeEvent with { Date = DateTime.Now, LawEnforcementId = 1 };
            _repository.CreateCrimeEventAsync(ev);
        }
    }
}