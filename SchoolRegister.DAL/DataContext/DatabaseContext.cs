using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.DAL.DataContext
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
		  : base(options)
		{
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Register> Register { get; set; }
		public DbSet<StudentClass> StudentClasses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().HasData(
				new Student()
				{
					Id = 001,
					FirstName = "Berry",
					LastName = "Krish",
					DateOfBirth = new DateTime(2000, 7, 23),
					Gender = "Female",
					Sport = "Football",

				},
				 new Student()
				 {
					 Id = 002,
					 FirstName = "Beil",
					 LastName = "Fish",
					 DateOfBirth = new DateTime(2011, 7, 23),
					 Gender = "Female",
					 Sport = "Gymnastic",

				 },
				  new Student()
				  {
					  Id = 003,
					  FirstName = "Berry",
					  LastName = "Salman",
					  DateOfBirth = new DateTime(2016, 7, 23),
					  Gender = "Female",
					  Sport = "Football",

				  },

				   new Student()
				   {
					   Id = 004,
					   FirstName = "Elder",
					   LastName = "Paul Beak Eldritch",
					   DateOfBirth = new DateTime(2013, 7, 23),
					   Gender = "male",
					   Sport = "Tennis",

				   },

					new Student()
					{
						Id = 005,
						FirstName = "Beak",
						LastName = "Griffin",
						DateOfBirth = new DateTime(2001, 7, 23),
						Gender = "male",
						Sport = "Football",

					},


					 new Student()
					 {
						 Id = 006,
						 FirstName = "Salami",
						 LastName = "Griffin",
						 DateOfBirth = new DateTime(2001, 4, 10),
						 Gender = "Female",
						 Sport = "Gymnastic",

					 },

					  new Student()
					  {
						  Id = 007,
						  FirstName = "Berry",
						  LastName = "Griffin Beak Eldritch",
						  DateOfBirth = new DateTime(2011, 7, 10),
						  Gender = "Female",
						  Sport = "Tenni",

					  });




			modelBuilder.Entity<Teacher>().HasData(
			   new Teacher()
			   {
				   TeacherId = 001,
				   FirstName = "Darliton",
				   LastName = "Emmanual",
				   Gender = "Male",

			   },

			   new Teacher()
			   {
				   TeacherId = 002,
				   FirstName = "Funmi",
				   LastName = "Emmanual",
				   Gender = "Female",

			   },


			   new Teacher()
			   {
				   TeacherId = 003,
				   FirstName = "Darliton",
				   LastName = "Emmanual",
				   Gender = "Male",

			   }
			   );
			modelBuilder.Entity<StudentClass>().HasData(
			  new StudentClass()
			  {
				  StudentClassId = 1,
				  Level = "Basic_1",
				  Teacher = 1
			  },

			  new StudentClass()
			  {
				  StudentClassId = 2,
				  Level = "Basic_2",
				  Teacher = 2
			  },
			  new StudentClass()
			  {
				  StudentClassId = 3,
				  Level = "Basic_3",
				  Teacher = 3
			  }

			  );



			base.OnModelCreating(modelBuilder);
		}
	}


}
