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
    [Migration("20200513225426_PopulateGender")]
    partial class PopulateGender
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolRegister.DAL.Entities.Gender", b =>
                {
                    b.Property<byte>("GenderId")
                        .HasColumnType("tinyint");

                    b.Property<string>("GenderType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

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

            modelBuilder.Entity("SchoolRegister.DAL.Entities.Sport", b =>
                {
                    b.Property<byte>("SportId")
                        .HasColumnType("tinyint");

                    b.Property<string>("SportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportId");

                    b.ToTable("Sport");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("GenderId")
                        .HasColumnType("tinyint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("SportId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("StudentClassId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("SportId");

                    b.HasIndex("StudentClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolRegister.DAL.Entities.StudentClass", b =>
                {
                    b.Property<byte>("StudentClassId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentClassId");

                    b.ToTable("StudentClasses");
                });

            modelBuilder.Entity("SchoolRegister.DAL.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("GenderId")
                        .HasColumnType("tinyint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("StudentClassId")
                        .HasColumnType("tinyint");

                    b.HasKey("TeacherId");

                    b.HasIndex("GenderId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolRegister.DAL.Entities.Student", b =>
                {
                    b.HasOne("SchoolRegister.DAL.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolRegister.DAL.Entities.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolRegister.DAL.Entities.StudentClass", "StudentCalss")
                        .WithMany()
                        .HasForeignKey("StudentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolRegister.DAL.Entities.Teacher", b =>
                {
                    b.HasOne("SchoolRegister.DAL.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
