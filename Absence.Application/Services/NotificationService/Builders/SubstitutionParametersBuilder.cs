using Absence.Application.Services.NotificationService.Parameters;
using Absence.Application.Interfaces.Services.NotificationSender;
using Absence.Domain.Interfaces.Repositories;
using Absence.Domain.Models.Constants;
using Absence.Application.Helpers;
using Absence.Domain.Models.Enums;
using Microsoft.Extensions.Configuration;

namespace Absence.Application.Services.NotificationService.Builders;

public class SubstitutionParametersBuilder : INotificationParametersBuilder
{
    private readonly IEmailFormattingService _mailFormatter;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string _domain;

    public SubstitutionParametersBuilder(IEmailFormattingService mailFormatter, IUnitOfWork unitOfWork,
        IConfiguration configuration)
    {
        _mailFormatter = mailFormatter;
        _unitOfWork = unitOfWork;

        _domain = configuration["EnvironmentDomain"];
    }

    public async Task<NotificationParameters> Build(BuilderOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        var dict = new Dictionary<string, string>();

        dict.Add(NotificationConstants.Domain, _domain);

        var substitution = await _unitOfWork.SubstitutionsRepository.GetById(options.SubstitutionId);
        
        var deputy = await _unitOfWork.EmployeesRepository.GetByPId(substitution.DeputyPId);
        
        switch (options.NotificationType)
        {
            case NotificationTypes.SubstitutionAdded:
                var employee = await _unitOfWork.EmployeesRepository.GetByPId(substitution.EmployeePId); 

                dict.Add(NotificationConstants.AddresseeName, deputy.PFirstName);
                dict.Add(NotificationConstants.SenderFirstname, employee.PFirstName);
                dict.Add(NotificationConstants.SenderLastName, employee.PSurname);
                dict.Add(NotificationConstants.DateStart, substitution.DateStart.ToString("d"));
                dict.Add(NotificationConstants.DateEnd, substitution.DateEnd.ToString("d"));

                break;
            default:
                ExceptionHelper.ThrowContextualException<InvalidOperationException>("This notification type is not allowen in this builder");
                break;
        }

        var parameters = new NotificationParameters();
        
        var body = await _unitOfWork.NotificationBodiesRepository.GetByTypeId((int)options.NotificationType);

        parameters.Title = await _unitOfWork.NotificationTitlesRepository.GetByTypeId((int)options.NotificationType);
        parameters.Body = _mailFormatter.ReplaceParams(body, dict);
        parameters.To = $"{deputy.Mail.ToLower()}";

        return parameters;
    }
}