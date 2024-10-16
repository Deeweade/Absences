namespace Absence.Application.Models.Views;

public class VacationDaysView : BaseView
{
    public string PId { get; set; }
    public int Year { get; set; }
    public int DaysNumber { get; set; }
    public bool IsYearPlanning { get; set; }
    public string AbsenceTypeId { get; set; }

    public AbsenceTypeView AbsenceType { get; set; }
}