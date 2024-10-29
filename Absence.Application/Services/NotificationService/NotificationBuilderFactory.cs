using Absence.Application.Interfaces.Services.NotificationSender.Builders;
using Absence.Application.Interfaces.Services.NotificationSender;
using Absence.Domain.Models.Enums;

namespace Absence.Application.Services.NotificationService;

public class NotificationBuilderFactory : INotificationBuilderFactory
{
    private readonly ISubstitutionParametersBuilder _substitutionParametersBuilder;
    private readonly IAbsenceParametersBuilder _absenceParametersBuilder;

    public NotificationBuilderFactory(IAbsenceParametersBuilder absenceParametersBuilder, 
        ISubstitutionParametersBuilder substitutionParametersBuilder)
    {
        _absenceParametersBuilder = absenceParametersBuilder;
        _substitutionParametersBuilder = substitutionParametersBuilder;
    }

    public INotificationParametersBuilder GetBuilder(NotificationSubjects builders)
    {
        switch (builders)
        {
            case NotificationSubjects.Absence:
                return _absenceParametersBuilder;
            case NotificationSubjects.Substitution:
                return _substitutionParametersBuilder;
            default:
                throw new Exception("There is no default notification parameters builder!");
        }
    }
}