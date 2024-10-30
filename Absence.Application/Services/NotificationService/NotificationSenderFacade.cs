using Absence.Application.Services.NotificationService.Parameters;
using Absence.Application.Interfaces.Services.NotificationSender;
using Absence.Application.Interfaces.Services;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Models.Enums;
using Absence.Domain.Interfaces.Repositories;

namespace Absence.Application.Services.NotificationService;

public class NotificationSenderFacade : INotificationSenderFacade
{
    private readonly INotificationBuilderFactory _factory;
    private readonly INotificationSender _sender;
    private readonly IUnitOfWork _unitOfWork;

    public NotificationSenderFacade(INotificationBuilderFactory factory, INotificationSender sender, 
        IUnitOfWork unitOfWork)
    {
        _factory = factory;
        _sender = sender;
        _unitOfWork = unitOfWork;
    }

    public async Task Send_AbsencesRequireApproval(string absenceOwnerPId)
    {
        ArgumentNullException.ThrowIfNull(absenceOwnerPId);

        var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        var options = new BuilderOptions
        {
            NotificationType = NotificationTypes.AbsencesRequireApproval,
            AbsenceOwnerPId = absenceOwnerPId
        };

        var parameters = await builder.Build(options);

        await Send(parameters);
    }

    public async Task Send_AllAbsencesApproved(string absenceOwnerPId)
    {
        ArgumentNullException.ThrowIfNull(absenceOwnerPId);

        var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        var options = new BuilderOptions
        {
            NotificationType = NotificationTypes.AllAbsencesApproved,
            AbsenceOwnerPId = absenceOwnerPId
        };

        var parameters = await builder.Build(options);

        await Send(parameters);
    }

    public async Task Send_AllAbsencesRejected(string absenceOwnerPId)
    {
        ArgumentNullException.ThrowIfNull(absenceOwnerPId);

        var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        var options = new BuilderOptions
        {
            NotificationType = NotificationTypes.AllAbsencesRejected,
            AbsenceOwnerPId = absenceOwnerPId
        };

        var parameters = await builder.Build(options);

        await Send(parameters);
    }

    public async Task Send_SubstitutionAdded(SubstitutionDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var builder = _factory.GetBuilder(NotificationSubjects.Substitution);

        var options = new BuilderOptions
        {
            NotificationType = NotificationTypes.SubstitutionAdded,
            SubstitutionId = dto.Id
        };

        var parameters = await builder.Build(options);

        await Send(parameters);
    }

    private async Task Send(NotificationParameters parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);

        parameters.From = await _unitOfWork.NotificationSettingsRepository.GetFrom();
        parameters.IsOverride = await _unitOfWork.NotificationSettingsRepository.IsOverride();
        parameters.DefaultEmail = await _unitOfWork.NotificationSettingsRepository.GetDefaultEmail();
        parameters.DisplayedName = await _unitOfWork.NotificationSettingsRepository.GetDisplayedName();
        parameters.MailServerAddress = "mail.rccf.ru";

        await _sender.Send(parameters);
    }
}