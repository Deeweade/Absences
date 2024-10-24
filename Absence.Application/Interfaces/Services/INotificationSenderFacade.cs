using Absence.Application.Models;
using Absence.Domain.Dtos.Entities;

namespace Absence.Application.Interfaces.Services;

public interface INotificationSenderFacade
{
    Task Send_AbsencesApproved(string pId);
    Task Send_AbsencesRejected(string pId);
    Task Send_AbsencesRequireApproval(string pId);
    Task Send_SubstitutionAdded(SubstitutionDto dto);
}
