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

    public async Task Send_AbsencesRequireApproval(string pId)
    {
        ArgumentNullException.ThrowIfNull(pId);

        var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        var parameters = await builder.Build(NotificationTypes.AbsencesRequireApproval, pId);

        await _sender.Send(parameters);
    }

    public async Task Send_AbsencesApproved(string pId)
    {
        ArgumentNullException.ThrowIfNull(pId);

        var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        var parameters = await builder.Build(NotificationTypes.AbsencesApproved, pId);

        await _sender.Send(parameters);
    }

    public async Task Send_AbsencesRejected(string pId)
    {
        ArgumentNullException.ThrowIfNull(pId);

        var builder = _factory.GetBuilder(NotificationSubjects.Absence);

        var parameters = await builder.Build(NotificationTypes.AbsencesRejected, pId);

        await _sender.Send(parameters);
    }

    public async Task Send_SubstitutionAdded(SubstitutionDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var builder = _factory.GetBuilder(NotificationSubjects.Substitution);

        var parameters = await builder.Build(NotificationTypes.SubstitutionAdded, dto.DeputyPId);

        await _sender.Send(parameters);
    }
}