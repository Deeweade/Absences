using Absence.Application.Interfaces.Services.NotificationSender.Builders;
using Absence.Domain.Models.Enums;

namespace Absence.Application.Services.NotificationService.Builders;

public class SubstitutionParametersBuilder : ISubstitutionParametersBuilder
{
    public Task<NotificationParameters> Build(NotificationTypes absencesRequireApproval, string pId)
    {
        throw new NotImplementedException();
    }
}
