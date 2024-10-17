using System.ComponentModel.DataAnnotations.Schema;

namespace Absence.Domain.Models.Entities;

[Table("Position_And_Employees_On_Day")]
public class PositionAndEmployees
{
    [Column("DATE_FIELD")]
    public DateTime? DateField { get; set; }

    [Column("TERMINATION_DATE")]
    public DateTime? TerminationDate { get; set; }

    [Column("SID")]
    public string SId { get; set; }

    [Column("SNAME")]
    public string SName { get; set; }

    [Column("SOPERCENT")]
    public decimal? SOPercent { get; set; }
    
    [Column("SPPERCENT")]
    public decimal? SPPercent { get; set; }

    [Column("PID")]
    public string PId { get; set; }

    [Column("PGRADE")]
    public string PGrade { get; set; }

    [Column("PGRADESTARTDATE")]
    public DateTime? PGradeStartDate { get; set; }

    [Column("PSURNAME")]
    public string PSurname { get; set; }

    [Column("PFIRSTNAME")]
    public string PFirstName { get; set; }
    
    [Column("PSECONDNAME")]
    public string PSecondName { get; set; }

    [Column("PGENDER")]
    public string PGender { get; set; }

    [Column("PBIRTHDAY")]
    public DateTime? PBirthDay { get; set; }

    [Column("MAIL")]
    public string Mail { get; set; }

    [Column("CITY_NAME")]
    public string CityName { get; set; }

    [Column("HIRED_DATE")]
    public DateTime? HiredDate { get; set; }

    [Column("OFFICENAME")]
    public string OfficeName { get; set; }

    [Column("CATEGORYNAME")]
    public string CategoryName { get; set; }

    [Column("CCID")]
    public string CCId { get; set; }

    [Column("OID")]
    public string OId { get; set; }

    [Column("LEVEL_1")]
    public string Level1 { get; set; }

    [Column("LEVEL_2")]
    public string Level2 { get; set; }

    [Column("LEVEL_3")]
    public string Level3 { get; set; }

    [Column("LEVEL_4")]
    public string Level4 { get; set; }

    [Column("LEVEL_5")]
    public string Level5 { get; set; }

    [Column("LEVEL_6")]
    public string Level6 { get; set; }

    [Column("LEVEL_7")]
    public string Level7 { get; set; }
}