using Absence.Application.Interfaces.Services.NotificationSender;
using Absence.Application.Services.NotificationService.Builders;
using Absence.Domain.Interfaces.Repositories;
using Absence.Domain.Models.Enums;
using Microsoft.Extensions.Configuration;

namespace Absence.Application.Services.NotificationService;

public class NotificationBuilderFactory : INotificationBuilderFactory
{
    private readonly IEmailFormattingService _mailFormatter;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;

    public NotificationBuilderFactory(IEmailFormattingService mailFormatter, IUnitOfWork unitOfWork, 
        IConfiguration configuration)
    {
        _mailFormatter = mailFormatter;
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public INotificationParametersBuilder GetBuilder(NotificationSubjects builders)
    {
        switch (builders)
        {
            case NotificationSubjects.Absence:
                return new AbsenceParametersBuilder(_mailFormatter, _unitOfWork, _configuration);
            case NotificationSubjects.Substitution:
                return new SubstitutionParametersBuilder(_mailFormatter, _unitOfWork, _configuration);
            default:
                throw new Exception("There is no default notification parameters builder!");
        }
    }
}