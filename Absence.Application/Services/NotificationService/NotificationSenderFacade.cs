using System;
using Absence.Application.Interfaces.Services;
using Absence.Application.Models;
using Absence.Domain.Dtos.Entities;

namespace Absence.Application.Services.NotificationService;

public class NotificationSenderFacade : INotificationSenderFacade
{
    public async Task Send_AbsencesRequireApproval(string pId)
    {
        ArgumentNullException.ThrowIfNull(pId);
    }

    public async Task Send_AbsencesApproved(string pId)
    {
        ArgumentNullException.ThrowIfNull(pId);
    }

    public async Task Send_AbsencesRejected(string pId)
    {
        ArgumentNullException.ThrowIfNull(pId);
    }

    public async Task Send_SubstitutionAdded(SubstitutionDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
    }
}