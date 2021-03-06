﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolRegister.DAL.DataContext;

namespace SchoolRegister.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200514165736_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolRegister.DAL.Entities.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Present")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("SchoolRegister.DAL.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sport")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTimeOffset(new DateTime(2000, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Berry",
                            Gender = "Female",
                            LastName = "Griffin Beak Eldritch",
                            Sport = "Football"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Beil",
                            Gender = "Female",
                            LastName = "Eldritch",
                            Sport = "Football"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Berry",
                            Gender = "Female",
                            LastName = "Griffin",
                            Sport = "Football"
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Elder",
                            Gender = "male",
                            LastName = "Paul Beak Eldritch",
                            Sport = "Football"
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTimeOffset(new DateTime(2001, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Beak",
                            Gender = "male",
                            LastName = "Griffin",
                            Sport = "Football"
                        },
                        new
                        {
                            Id = 6,
                            DateOfBirth = new DateTimeOffset(new DateTime(2001, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Salami",
                            Gender = "Female",
                            LastName = "Griffin",
                            Sport = "Football"
                        },
                        new
                        {
                            Id = 7,
                            DateOfBirth = new DateTimeOffset(new DateTime(2011, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Berry",
                            Gender = "Female",
                            LastName = "Griffin Beak Eldritch",
                            Sport = "Football"
                        });
                });

            modelBuilder.Entity("SchoolRegister.DAL.Entities.StudentClass", b =>
                {
                    b.Property<byte>("StudentClassId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentClassId");

                    b.ToTable("StudentClasses");

                    b.HasData(
                        new
                        {
                            StudentClassId = (byte)1,
                            Level = "Basic_1"
                        },
                        new
                        {
                            StudentClassId = (byte)2,
                            Level = "Basic_2"
                        },
                        new
                        {
                            StudentClassId = (byte)3,
                            Level = "Basic_3"
                        });
                });

            modelBuilder.Entity("SchoolRegister.DAL.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("StudentClassId")
                        .HasColumnType("tinyint");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            FirstName = "Darliton",
                            Gender = "Male",
                            LastName = "Emmanual",
                            StudentClassId = (byte)0
                        },
                        new
                        {
                            TeacherId = 2,
                            FirstName = "Funmi",
                            Gender = "Female",
                            LastName = "Emmanual",
                            StudentClassId = (byte)0
                        },
                        new
                        {
                            TeacherId = 3,
                            FirstName = "Darliton",
                            Gender = "Male",
                            LastName = "Emmanual",
                            StudentClassId = (byte)0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
