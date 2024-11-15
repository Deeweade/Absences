﻿// <auto-generated />
using System;
using Absence.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Absence.API.Migrations
{
    [DbContext(typeof(AbsenceDbContext))]
    [Migration("20241030144031_NotificationSettings_Table_Added")]
    partial class NotificationSettings_Table_Added
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Absence.Domain.Models.Entities.Absence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AbsenceStatusId")
                        .HasColumnType("int");

                    b.Property<string>("AbsenceTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("PId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentAbsenceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbsenceStatusId");

                    b.HasIndex("AbsenceTypeId");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.AbsenceStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AbsenceStatuses");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.AbsenceType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AbsenceTypes");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StageId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.EmployeeStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StageId");

                    b.ToTable("EmployeeStages");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.NotificationBody", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NotificationMethodId")
                        .HasColumnType("int");

                    b.Property<int>("NotificationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NotificationMethodId");

                    b.HasIndex("NotificationTypeId");

                    b.ToTable("NotificationBodies");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.NotificationMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NotificationMethods");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.NotificationSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NotificationSettings");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.NotificationTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NotificationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NotificationTypeId");

                    b.ToTable("NotificationTitles");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.NotificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NotificationTypes");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.PlanningProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PlanningProcesses");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.PositionAndEmployees", b =>
                {
                    b.Property<string>("CCId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CCID");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CATEGORYNAME");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CITY_NAME");

                    b.Property<DateTime?>("DateField")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_FIELD");

                    b.Property<DateTime?>("HiredDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("HIRED_DATE");

                    b.Property<string>("Level1")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LEVEL_1");

                    b.Property<string>("Level2")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LEVEL_2");

                    b.Property<string>("Level3")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LEVEL_3");

                    b.Property<string>("Level4")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LEVEL_4");

                    b.Property<string>("Level5")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LEVEL_5");

                    b.Property<string>("Level6")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LEVEL_6");

                    b.Property<string>("Level7")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LEVEL_7");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MAIL");

                    b.Property<string>("ManagerFirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MANAGER_FIRSTNAME");

                    b.Property<string>("ManagerPId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MANAGER_PID");

                    b.Property<string>("ManagerSecondName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MANAGER_SECONDNAME");

                    b.Property<string>("ManagerSurname")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MANAGER_SURNAME");

                    b.Property<string>("OId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OID");

                    b.Property<string>("OfficeName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OFFICENAME");

                    b.Property<DateTime?>("PBirthDay")
                        .HasColumnType("datetime2")
                        .HasColumnName("PBIRTHDAY");

                    b.Property<string>("PFirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PFIRSTNAME");

                    b.Property<string>("PGender")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PGENDER");

                    b.Property<string>("PGrade")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PGRADE");

                    b.Property<DateTime?>("PGradeStartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("PGRADESTARTDATE");

                    b.Property<string>("PId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PID");

                    b.Property<string>("PSecondName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PSECONDNAME");

                    b.Property<string>("PSurname")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PSURNAME");

                    b.Property<string>("SId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SID");

                    b.Property<string>("SName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SNAME");

                    b.Property<decimal?>("SOPercent")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("SOPERCENT");

                    b.Property<decimal?>("SPPercent")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("SPPERCENT");

                    b.Property<DateTime?>("TerminationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("TERMINATION_DATE");

                    b.ToTable("Position_And_Employees_On_Day");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.ProcessStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("ProcessStages");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.Substitution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeputyPId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Substitutions");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.SystemProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.VacationDays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AbsenceTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AvailableDaysNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsYearPlanning")
                        .HasColumnType("bit");

                    b.Property<string>("PId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlannedDaysNumber")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbsenceTypeId");

                    b.ToTable("VacationDays");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.WorkPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkdayTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkdayTypeId");

                    b.ToTable("WorkPeriods");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.WorkdayType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkdayTypes");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.Absence", b =>
                {
                    b.HasOne("Absence.Domain.Models.Entities.AbsenceStatus", "AbsenceStatus")
                        .WithMany("Absences")
                        .HasForeignKey("AbsenceStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Absence.Domain.Models.Entities.AbsenceType", "AbsenceType")
                        .WithMany("Absences")
                        .HasForeignKey("AbsenceTypeId");

                    b.Navigation("AbsenceStatus");

                    b.Navigation("AbsenceType");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.Comment", b =>
                {
                    b.HasOne("Absence.Domain.Models.Entities.EmployeeStage", "Stage")
                        .WithMany("Comments")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.EmployeeStage", b =>
                {
                    b.HasOne("Absence.Domain.Models.Entities.ProcessStage", "Stage")
                        .WithMany("EmployeeStages")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.NotificationBody", b =>
                {
                    b.HasOne("Absence.Domain.Models.Entities.NotificationMethod", "NotificationMethod")
                        .WithMany("Bodies")
                        .HasForeignKey("NotificationMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Absence.Domain.Models.Entities.NotificationType", "NotificationType")
                        .WithMany("Bodies")
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotificationMethod");

                    b.Navigation("NotificationType");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.NotificationTitle", b =>
                {
                    b.HasOne("Absence.Domain.Models.Entities.NotificationType", "NotificationType")
                        .WithMany("Titles")
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotificationType");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.ProcessStage", b =>
                {
                    b.HasOne("Absence.Domain.Models.Entities.SystemProcess", "Process")
                        .WithMany("Stages")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.VacationDays", b =>
                {
                    b.HasOne("Absence.Domain.Models.Entities.AbsenceType", "AbsenceType")
                        .WithMany("VacationDays")
                        .HasForeignKey("AbsenceTypeId");

                    b.Navigation("AbsenceType");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.WorkPeriod", b =>
                {
                    b.HasOne("Absence.Domain.Models.Entities.WorkdayType", "WorkdayType")
                        .WithMany("WorkPeriods")
                        .HasForeignKey("WorkdayTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkdayType");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.AbsenceStatus", b =>
                {
                    b.Navigation("Absences");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.AbsenceType", b =>
                {
                    b.Navigation("Absences");

                    b.Navigation("VacationDays");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.EmployeeStage", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.NotificationMethod", b =>
                {
                    b.Navigation("Bodies");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.NotificationType", b =>
                {
                    b.Navigation("Bodies");

                    b.Navigation("Titles");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.ProcessStage", b =>
                {
                    b.Navigation("EmployeeStages");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.SystemProcess", b =>
                {
                    b.Navigation("Stages");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.WorkdayType", b =>
                {
                    b.Navigation("WorkPeriods");
                });
#pragma warning restore 612, 618
        }
    }
}
