﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Absence.Infrastructure.Data.Contexts;

#nullable disable

namespace Absence.API.Migrations
{
    [DbContext(typeof(AbsenceDbContext))]
    [Migration("20241011102131_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<int>("DaysNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsYearPlanning")
                        .HasColumnType("bit");

                    b.Property<string>("PId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AbsenceTypeId");

                    b.ToTable("VacationDays");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.WorkPeriods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsWorkingDay")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("WorkPeriods");
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

            modelBuilder.Entity("Absence.Domain.Models.Entities.ProcessStage", b =>
                {
                    b.Navigation("EmployeeStages");
                });

            modelBuilder.Entity("Absence.Domain.Models.Entities.SystemProcess", b =>
                {
                    b.Navigation("Stages");
                });
#pragma warning restore 612, 618
        }
    }
}
