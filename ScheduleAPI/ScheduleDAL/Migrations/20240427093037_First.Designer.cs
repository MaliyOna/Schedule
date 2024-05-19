﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScheduleDAL;

#nullable disable

namespace ScheduleDAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240427093037_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScheduleDAL.Entities.MealEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ScheduleEntityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeOnly>("Teme")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleEntityId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("ScheduleDAL.Entities.ScheduleEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TimeForRest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ScheduleDAL.Entities.ToDoEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ScheduleEntityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TimeInWeek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleEntityId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("ScheduleDAL.Entities.MealEntity", b =>
                {
                    b.HasOne("ScheduleDAL.Entities.ScheduleEntity", null)
                        .WithMany("MealEntities")
                        .HasForeignKey("ScheduleEntityId");
                });

            modelBuilder.Entity("ScheduleDAL.Entities.ToDoEntity", b =>
                {
                    b.HasOne("ScheduleDAL.Entities.ScheduleEntity", null)
                        .WithMany("ToDoEntities")
                        .HasForeignKey("ScheduleEntityId");
                });

            modelBuilder.Entity("ScheduleDAL.Entities.ScheduleEntity", b =>
                {
                    b.Navigation("MealEntities");

                    b.Navigation("ToDoEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
