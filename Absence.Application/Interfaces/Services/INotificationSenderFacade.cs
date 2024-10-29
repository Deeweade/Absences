using Absence.Domain.Dtos.Entities;

namespace Absence.Application.Interfaces.Services;

public interface INotificationSenderFacade
{
    Task Send_AllAbsencesApproved(string pId);
    Task Send_AllAbsencesRejected(string pId);
    Task Send_AbsencesRequireApproval(string absenceOwnerPId);
    Task Send_SubstitutionAdded(SubstitutionDto dto);
}
