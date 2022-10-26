using AutoMapper;
using Crime.Application.Crime.Messaging.Receive;
using Crime.Application.Crime.Messaging_Send;
using Crime.Application.Interfaces;
using Crime.Application.Services.Interfaces;
using Crime.Domain.Entities;
using Crime.Domain.Entities.Enums;
using REP_CRIME._01.Common.Dto;
using REP_CRIME._01.Common.Exceptions;

namespace Crime.Application.Services
{
    public class CrimeEventsService : ICrimeEventsService
    {
        private readonly ICrimeEventsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICrimeEventSender _crimeEventSender;

        public CrimeEventsService(ICrimeEventsRepository repository, IMapper mapper, ICrimeEventSender crimeEventSender)
        {
            _repository = repository;
            _mapper = mapper;
            _crimeEventSender = crimeEventSender;
        }

        public async Task<IEnumerable<CrimeEventDto>> GetAllCrimeEventsAsync()
        {
            var crimeEvents = await _repository.GetCrimeEventsAsync();
            var mappedCrimeEvents = _mapper.Map<IEnumerable<CrimeEventDto>>(crimeEvents);
            if (mappedCrimeEvents == null)
                throw new ResourceNotFoundException("Crime events not found");
            return mappedCrimeEvents;
        }

        public async Task<CrimeEventDto> GetCrimeEventAsync(Guid eventId)
        {
            var crimeEvent = await _repository.GetCrimeEventAsync(eventId);
            var mappedCrimeEvent = _mapper.Map<CrimeEventDto>(crimeEvent);
            if (mappedCrimeEvent == null)
                throw new ResourceNotFoundException("Crime event not found");
            return mappedCrimeEvent;
        }

        public async Task CreateNewCrimeEventAsync(CreateCrimeEventDto newCrimeEventDto)
        {
            var newCrimeEventMapped = _mapper.Map<CrimeEvent>(newCrimeEventDto);
            var crimeEventToAdd = newCrimeEventMapped with { Date = DateTime.Now, EventId = Guid.NewGuid() };
            var eventToSend = _mapper.Map<CrimeEventDto>(crimeEventToAdd);
            _crimeEventSender.SendCrimeEvent(eventToSend);
            await _repository.CreateCrimeEventAsync(crimeEventToAdd);
        }

        public async Task AssignLawEnforcementToCrimeEvent(Guid crimeId, int EnforcementId)
        {
            var crimeEvent = await _repository.GetCrimeEventAsync(crimeId);
            var crimeEventToAdd = crimeEvent with { LawEnforcementId = EnforcementId, Status = CrimeStatus.Assigned };
            await _repository.UpdateCrimeEventAsync(crimeEventToAdd);
        }
    }
}