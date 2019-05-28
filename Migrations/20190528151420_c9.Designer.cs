﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using samis.Data;

namespace samis.Migrations
{
    [DbContext(typeof(SamisDbContext))]
    [Migration("20190528151420_c9")]
    partial class c9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("samis.Models.ActivityInformation", b =>
                {
                    b.Property<int>("activityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("activityName");

                    b.Property<int>("activityTypeId");

                    b.Property<int>("activityUnitId");

                    b.Property<int>("advisorId");

                    b.Property<DateTime?>("endDate");

                    b.Property<int>("participant");

                    b.Property<int>("projectLevelId");

                    b.Property<string>("referenceNumber");

                    b.Property<int>("semester");

                    b.Property<DateTime?>("startDate");

                    b.Property<int>("statusTypeId");

                    b.Property<string>("venue");

                    b.Property<int>("year");

                    b.HasKey("activityId");

                    b.HasIndex("activityTypeId");

                    b.HasIndex("activityUnitId");

                    b.HasIndex("advisorId");

                    b.HasIndex("projectLevelId");

                    b.HasIndex("statusTypeId");

                    b.ToTable("ActivityInformations");
                });

            modelBuilder.Entity("samis.Models.ActivityType", b =>
                {
                    b.Property<int>("activityTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("activityTypeName");

                    b.HasKey("activityTypeId");

                    b.ToTable("ActivityTypes");
                });

            modelBuilder.Entity("samis.Models.ActivityUnit", b =>
                {
                    b.Property<int>("activityUnitId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("advisorId");

                    b.Property<string>("name");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasKey("activityUnitId");

                    b.HasIndex("advisorId");

                    b.ToTable("ActivityUnits");
                });

            modelBuilder.Entity("samis.Models.Advisor", b =>
                {
                    b.Property<int>("advisorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("advisorPositionId");

                    b.Property<string>("email");

                    b.Property<string>("lineID");

                    b.Property<string>("name");

                    b.Property<string>("phoneNumber");

                    b.HasKey("advisorId");

                    b.HasIndex("advisorPositionId");

                    b.ToTable("Advisors");
                });

            modelBuilder.Entity("samis.Models.AdvisorPosition", b =>
                {
                    b.Property<int>("advisorPositionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("advisorPositionName");

                    b.HasKey("advisorPositionId");

                    b.ToTable("AdvisorPositions");
                });

            modelBuilder.Entity("samis.Models.Budget", b =>
                {
                    b.Property<int>("budgetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("activityId");

                    b.Property<double>("amount");

                    b.Property<int>("budgetStatusId");

                    b.Property<int>("budgetTypeId");

                    b.Property<string>("name");

                    b.HasKey("budgetId");

                    b.HasIndex("activityId");

                    b.HasIndex("budgetStatusId");

                    b.HasIndex("budgetTypeId");

                    b.ToTable("Bugets");
                });

            modelBuilder.Entity("samis.Models.BudgetStatus", b =>
                {
                    b.Property<int>("budgetStatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("budgetStatusId");

                    b.ToTable("BudgetStatus");
                });

            modelBuilder.Entity("samis.Models.BudgetType", b =>
                {
                    b.Property<int>("budgetTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("budgetTypeName");

                    b.HasKey("budgetTypeId");

                    b.ToTable("BudgetTypes");
                });

            modelBuilder.Entity("samis.Models.LocationType", b =>
                {
                    b.Property<int>("locationTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("locationTypeName");

                    b.HasKey("locationTypeId");

                    b.ToTable("LocationTypes");
                });

            modelBuilder.Entity("samis.Models.OrganizerType", b =>
                {
                    b.Property<int>("organizerTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("organizerTypeName");

                    b.HasKey("organizerTypeId");

                    b.ToTable("OrganizerTypes");
                });

            modelBuilder.Entity("samis.Models.Origanizer", b =>
                {
                    b.Property<int>("organizerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("activityId");

                    b.Property<string>("email");

                    b.Property<int>("organierTypeId");

                    b.Property<int?>("organizerTypeId");

                    b.Property<int>("phoneNumber");

                    b.Property<int>("studentId");

                    b.HasKey("organizerId");

                    b.HasIndex("activityId");

                    b.HasIndex("organizerTypeId");

                    b.HasIndex("studentId");

                    b.ToTable("Origanizers");
                });

            modelBuilder.Entity("samis.Models.Praticipant", b =>
                {
                    b.Property<int>("participantId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("activityId");

                    b.Property<string>("email");

                    b.Property<int>("phoneNumber");

                    b.Property<int>("studentId");

                    b.HasKey("participantId");

                    b.HasIndex("activityId");

                    b.HasIndex("studentId");

                    b.ToTable("Praticipants");
                });

            modelBuilder.Entity("samis.Models.ProjectLevel", b =>
                {
                    b.Property<int>("projectLevelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("projectLevelId");

                    b.ToTable("ProjectLevels");
                });

            modelBuilder.Entity("samis.Models.StatusType", b =>
                {
                    b.Property<int>("statusTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("statusTypeName");

                    b.HasKey("statusTypeId");

                    b.ToTable("StatusTypes");
                });

            modelBuilder.Entity("samis.Models.Student", b =>
                {
                    b.Property<int>("studentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("studentCode");

                    b.Property<string>("studentName");

                    b.HasKey("studentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("samis.Models.ActivityInformation", b =>
                {
                    b.HasOne("samis.Models.ActivityType", "activityType")
                        .WithMany()
                        .HasForeignKey("activityTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("samis.Models.ActivityUnit", "activityUnit")
                        .WithMany()
                        .HasForeignKey("activityUnitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("samis.Models.Advisor", "advisor")
                        .WithMany()
                        .HasForeignKey("advisorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("samis.Models.ProjectLevel", "projectLevel")
                        .WithMany()
                        .HasForeignKey("projectLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("samis.Models.StatusType", "statusType")
                        .WithMany()
                        .HasForeignKey("statusTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("samis.Models.ActivityUnit", b =>
                {
                    b.HasOne("samis.Models.Advisor", "advisor")
                        .WithMany()
                        .HasForeignKey("advisorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("samis.Models.Advisor", b =>
                {
                    b.HasOne("samis.Models.AdvisorPosition", "advisorPosition")
                        .WithMany()
                        .HasForeignKey("advisorPositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("samis.Models.Budget", b =>
                {
                    b.HasOne("samis.Models.ActivityInformation", "activityInformation")
                        .WithMany()
                        .HasForeignKey("activityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("samis.Models.BudgetStatus", "budgetStatus")
                        .WithMany()
                        .HasForeignKey("budgetStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("samis.Models.BudgetType", "budgetType")
                        .WithMany()
                        .HasForeignKey("budgetTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("samis.Models.Origanizer", b =>
                {
                    b.HasOne("samis.Models.ActivityInformation", "ActivityInformation")
                        .WithMany()
                        .HasForeignKey("activityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("samis.Models.OrganizerType", "organizerType")
                        .WithMany()
                        .HasForeignKey("organizerTypeId");

                    b.HasOne("samis.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("samis.Models.Praticipant", b =>
                {
                    b.HasOne("samis.Models.ActivityInformation", "activityInformation")
                        .WithMany()
                        .HasForeignKey("activityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("samis.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
