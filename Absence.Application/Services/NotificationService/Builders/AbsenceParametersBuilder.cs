using Absence.Application.Interfaces.Services.NotificationSender;
using Absence.Application.Interfaces.Services.NotificationSender.Builders;
using Absence.Domain.Interfaces.Repositories;
using Absence.Domain.Models.Enums;

namespace Absence.Application.Services.NotificationService.Builders;

public class AbsenceParametersBuilder : IAbsenceParametersBuilder
{
    //private readonly IEmailFormattingService _mailFormatter;
    private readonly IUnitOfWork _unitOfWork;

    public AbsenceParametersBuilder(//IEmailFormattingService mailFormatter, 
        IUnitOfWork unitOfWork)
    {
        //_mailFormatter = mailFormatter;
        _unitOfWork = unitOfWork;
    }

    public async Task<NotificationParameters> Build(NotificationTypes notificationType, string pId)
    {
        ArgumentNullException.ThrowIfNull(pId);

        switch (notificationType)
        {
            case NotificationTypes.AbsenceAdded:
                break;
            case NotificationTypes.AbsencesRequireApproval:
                break;
            case NotificationTypes.AbsencesRejected:
                break;
            case NotificationTypes.AbsencesApproved:
                break;
        }

        var parameters = new NotificationParameters();

        return parameters;
    }
}