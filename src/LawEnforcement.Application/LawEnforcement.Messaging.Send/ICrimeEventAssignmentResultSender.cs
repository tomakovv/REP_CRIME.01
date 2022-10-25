using REP_CRIME._01.Common.Dto;

namespace LawEnforcement.Application.LawEnforcement.Messaging.Send
{
    public interface ICrimeEventAssignmentResultSender
    {
        void SendCrimeEventAssignmentResult(AssignmentResult result);
    }
}