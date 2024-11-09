using Absence.Application.Services.NotificationService.Parameters;
using Absence.Application.Interfaces.Services.NotificationSender;
using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Models.Enums;

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

    public async Task Send_AbsenceApproved(AbsenceDto absence)
    {
        ArgumentNullException.ThrowIfNull(absence);

        var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        var options = new BuilderOptions
        {
            NotificationType = NotificationTypes.AbsenceApproved,
            AbsenceOwnerPId = absence.PId,
            AbsenceId = absence.Id
        };

        var parameters = await builder.Build(options);

        await Send(parameters);
    }

    public async Task Send_AbsenceRejected(AbsenceDto absence)
    {
        ArgumentNullException.ThrowIfNull(absence);

        var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        var options = new BuilderOptions
        {
            NotificationType = NotificationTypes.AbsenceRejected,
            AbsenceOwnerPId = absence.PId,
            AbsenceId = absence.Id
        };

        var parameters = await builder.Build(options);

        await Send(parameters);
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

        parameters.MailServerAddress = "mail.rccf.ru";
        parameters.From = await _unitOfWork.NotificationSettingsRepository.GetFrom();
        parameters.IsOverride = await _unitOfWork.NotificationSettingsRepository.IsOverride();
        parameters.DefaultEmail = await _unitOfWork.NotificationSettingsRepository.GetDefaultEmail();
        parameters.DisplayedName = await _unitOfWork.NotificationSettingsRepository.GetDisplayedName();

        await _sender.Send(parameters);
    }
}