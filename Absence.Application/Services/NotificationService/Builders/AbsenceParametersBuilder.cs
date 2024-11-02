using Absence.Application.Services.NotificationService.Parameters;
using Absence.Application.Interfaces.Services.NotificationSender;
using Absence.Domain.Interfaces.Repositories;
using Absence.Domain.Models.Constants;
using Absence.Domain.Models.Enums;
using Absence.Application.Helpers;
using Microsoft.Extensions.Configuration;
using Absence.Domain.Dtos.Queries;

namespace Absence.Application.Services.NotificationService.Builders;

public class AbsenceParametersBuilder : INotificationParametersBuilder
{
    private readonly IEmailFormattingService _mailFormatter;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string _domain;

    public AbsenceParametersBuilder(IEmailFormattingService mailFormatter, IUnitOfWork unitOfWork,
        IConfiguration configuration)
    {
        _mailFormatter = mailFormatter;
        _unitOfWork = unitOfWork;

        _domain = configuration["EnvironmentDomain"];
    }

    public async Task<NotificationParameters> Build(BuilderOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        
        var parameters = new NotificationParameters();

        var dict = new Dictionary<string, string>();

        dict.Add(NotificationConstants.Domain, _domain);

        var addressee = await _unitOfWork.EmployeesRepository.GetByPId(options.AbsenceOwnerPId);
        
        switch (options.NotificationType)
        {
            case NotificationTypes.AbsencesRequireApproval:
                var owner = await _unitOfWork.EmployeesRepository.GetByPId(options.AbsenceOwnerPId);

                addressee = await _unitOfWork.EmployeesRepository.GetByPId(owner.ManagerPId);
                
                var substitutions = await _unitOfWork.SubstitutionsRepository.GetCurrentByEmployeeId(addressee.PId);

                var deputiesPIds = substitutions.Select(x => x.DeputyPId).Distinct().ToList();

                if (deputiesPIds.Any())
                {
                    var deputiesEmails = await _unitOfWork.EmployeesRepository.GetByQuery(new EmployeesQueryDto
                    {
                        PIds = deputiesPIds
                    }, x => x.Mail.ToLower());

                    parameters.CC = deputiesEmails;
                }

                dict.Add(NotificationConstants.AddresseeName, addressee.PFirstName);
                dict.Add(NotificationConstants.SenderFirstname, owner.PFirstName);
                dict.Add(NotificationConstants.SenderLastName, owner.PSurname);

                break;
            case NotificationTypes.AllAbsencesRejected:

                dict.Add(NotificationConstants.AddresseeName, addressee.PFirstName);

                break;
            case NotificationTypes.AbsenceRejected:
                var absence = await _unitOfWork.AbsencesRepository.GetById(options.AbsenceId);
                addressee = await _unitOfWork.EmployeesRepository.GetByPId(absence.PId);

                dict.Add(NotificationConstants.AddresseeName, addressee.PFirstName);
                dict.Add(NotificationConstants.DateStart, absence.DateStart.ToString("d"));
                dict.Add(NotificationConstants.DateEnd, absence.DateEnd.ToString("d"));

                break;
            case NotificationTypes.AllAbsencesApproved:

                dict.Add(NotificationConstants.AddresseeName, addressee.PFirstName);

                break;
            case NotificationTypes.AbsenceApproved:
                absence = await _unitOfWork.AbsencesRepository.GetById(options.AbsenceId);
                addressee = await _unitOfWork.EmployeesRepository.GetByPId(absence.PId);

                dict.Add(NotificationConstants.AddresseeName, addressee.PFirstName);
                dict.Add(NotificationConstants.DateStart, absence.DateStart.ToString("d"));
                dict.Add(NotificationConstants.DateEnd, absence.DateEnd.ToString("d"));

                break;
            default:
                ExceptionHelper.ThrowContextualException<InvalidOperationException>("This notification type is not allowen in this builder");
                break;
        }
        
        var body = await _unitOfWork.NotificationBodiesRepository.GetByTypeId((int)options.NotificationType);

        parameters.Title = await _unitOfWork.NotificationTitlesRepository.GetByTypeId((int)options.NotificationType);
        parameters.Body = _mailFormatter.ReplaceParams(body, dict);
        parameters.To = $"{addressee.Mail.ToLower()}";

        return parameters;
    }
}