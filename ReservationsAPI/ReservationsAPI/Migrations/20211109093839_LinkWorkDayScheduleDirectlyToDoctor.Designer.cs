﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservationsAPI.DAL;

namespace ReservationsAPI.Migrations
{
    [DbContext(typeof(ReservationsContext))]
    [Migration("20211109093839_LinkWorkDayScheduleDirectlyToDoctor")]
    partial class LinkWorkDayScheduleDirectlyToDoctor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReservationsAPI.DAL.Entities.Appointment", b =>
                {
                    b.Property<long>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<long>("PacientId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProcedureId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.HasKey("DoctorId", "PacientId", "ProcedureId", "StartTime");

                    b.HasIndex("PacientId");

                    b.HasIndex("ProcedureId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ReservationsAPI.DAL.Entities.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ReservationsAPI.DAL.Entities.Pacient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pacients");
                });

            modelBuilder.Entity("ReservationsAPI.DAL.Entities.Procedure", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("ProcedureName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("ReservationsAPI.DAL.Entities.WorkDaySchedule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BreakEndHour")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BreakStartHour")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<long>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndHour")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartHour")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("WorkDaySchedules");
                });

            modelBuilder.Entity("ReservationsAPI.DAL.Entities.Appointment", b =>
                {
                    b.HasOne("ReservationsAPI.DAL.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservationsAPI.DAL.Entities.Pacient", "Pacient")
                        .WithMany("Appointments")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservationsAPI.DAL.Entities.Procedure", "Procedure")
                        .WithMany("Appointments")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Pacient");

                    b.Navigation("Procedure");
                });

            modelBuilder.Entity("ReservationsAPI.DAL.Entities.WorkDaySchedule", b =>
                {
                    b.HasOne("ReservationsAPI.DAL.Entities.Doctor", "Doctor")
                        .WithMany("WorkDaySchedules")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("ReservationsAPI.DAL.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("WorkDaySchedules");
                });

            modelBuilder.Entity("ReservationsAPI.DAL.Entities.Pacient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("ReservationsAPI.DAL.Entities.Procedure", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
