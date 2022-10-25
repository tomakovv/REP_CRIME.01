using REP_CRIME._01.Common.Dto;

namespace Crime.Application.Crime.Messaging_Send
{
    public interface ICrimeEventSender
    {
        void SendCrimeEvent(CrimeEventDto data);
    }
}