namespace Vacations.Domain.Dtos.Entities;

public abstract class HistoryEntityDto : BaseEntityDto
{
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}