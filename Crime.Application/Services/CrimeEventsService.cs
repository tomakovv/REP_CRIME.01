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

        public async Task<IEnumerable<CrimeEventDto>> GetAllCrimeEventsDtoAsync()
        {
            var crimeEvents = await _repository.GetCrimeEventsAsync();
            var mappedCrimeEvents = _mapper.Map<IEnumerable<CrimeEventDto>>(crimeEvents);
            if (mappedCrimeEvents == null)
                throw new Exception("Crime events not found");
            return mappedCrimeEvents;
        }
    }
}