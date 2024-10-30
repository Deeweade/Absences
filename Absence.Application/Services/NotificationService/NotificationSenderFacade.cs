using Absence.Application.Services.NotificationService.Parameters;
using Absence.Application.Interfaces.Services.NotificationSender;
using Absence.Application.Interfaces.Services;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Models.Enums;

namespace Absence.Application.Services.NotificationService;

public class NotificationSenderFacade : INotificationSenderFacade
{
    private readonly INotificationBuilderFactory _factory;
    private readonly INotificationSender _sender;

    public NotificationSenderFacade(INotificationBuilderFactory factory, INotificationSender sender)
    {
        _factory = factory;
        _sender = sender;
    }

    public async Task Send_AbsencesRequireApproval(string absenceOwnerPId)
    {
        ArgumentNullException.ThrowIfNull(absenceOwnerPId);

        // var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        // var options = new BuilderOptions
        // {
        //     NotificationType = NotificationTypes.AbsencesRequireApproval,
        //     AbsenceOwnerPId = absenceOwnerPId
        // };

        // var parameters = await builder.Build(options);

        // await Send(parameters);
    }

    public async Task Send_AllAbsencesApproved(string absenceOwnerPId)
    {
        ArgumentNullException.ThrowIfNull(absenceOwnerPId);

        // var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        // var options = new BuilderOptions
        // {
        //     NotificationType = NotificationTypes.AllAbsencesApproved,
        //     AbsenceOwnerPId = absenceOwnerPId
        // };

        // var parameters = await builder.Build(options);

        // await Send(parameters);
    }

    public async Task Send_AllAbsencesRejected(string absenceOwnerPId)
    {
        ArgumentNullException.ThrowIfNull(absenceOwnerPId);

        // var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        // var options = new BuilderOptions
        // {
        //     NotificationType = NotificationTypes.AllAbsencesRejected,
        //     AbsenceOwnerPId = absenceOwnerPId
        // };

        // var parameters = await builder.Build(options);

        // await Send(parameters);
    }

    public async Task Send_SubstitutionAdded(SubstitutionDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        // var builder = _factory.GetBuilder(NotificationSubjects.Substitution);

        // var options = new BuilderOptions
        // {
        //     NotificationType = NotificationTypes.SubstitutionAdded,
        //     SubstitutionId = dto.Id
        // };

        // var parameters = await builder.Build(options);

        // await Send(parameters);
    }

    private async Task Send(NotificationParameters parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);

        parameters.From = "";
        parameters.DisplayedName = "";
        parameters.MailServerAddress = "";

        await _sender.Send(parameters);
    }
}