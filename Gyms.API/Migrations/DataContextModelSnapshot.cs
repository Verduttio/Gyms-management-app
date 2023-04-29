﻿// <auto-generated />
using System;
using Gyms.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gyms.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gyms.API.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OpeningHoursId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OpeningHoursId")
                        .IsUnique();

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Gyms.API.Entities.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("YearOfBirth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("Gyms.API.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Cancelled")
                        .HasColumnType("bit");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("ParticipantsLimit")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantsNumber")
                        .HasColumnType("int");

                    b.Property<bool>("Regular")
                        .HasColumnType("bit");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("CoachId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Gyms.API.Entities.OpeningHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("FridayFrom")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("FridayTo")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("MondayFrom")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("MondayTo")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("SaturdayFrom")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("SaturdayTo")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("SundayFrom")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("SundayTo")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("ThursdayFrom")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("ThursdayTo")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("TuesdayFrom")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("TuesdayTo")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("WednesdayFrom")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("WednesdayTo")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("OpeningHours");
                });

            modelBuilder.Entity("Gyms.API.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Gyms.API.Entities.Club", b =>
                {
                    b.HasOne("Gyms.API.Entities.OpeningHours", "OpeningHours")
                        .WithOne("Club")
                        .HasForeignKey("Gyms.API.Entities.Club", "OpeningHoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OpeningHours");
                });

            modelBuilder.Entity("Gyms.API.Entities.Event", b =>
                {
                    b.HasOne("Gyms.API.Entities.Club", "Club")
                        .WithMany("Events")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gyms.API.Entities.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("Gyms.API.Entities.Reservation", b =>
                {
                    b.HasOne("Gyms.API.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Gyms.API.Entities.Club", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Gyms.API.Entities.OpeningHours", b =>
                {
                    b.Navigation("Club")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
