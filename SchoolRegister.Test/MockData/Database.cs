using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.Test.MockData
{ 
	public class Database: DbContext
	{
		public Database(DbContextOptions<Database> options) : base(options) { }
		public DbSet<Student> Students { get; set; }

		private void InitDbContext(Database context)
		{
			context.Students.Add(new Student { 
				Id = 1,
				FirstName = "Mike",
				LastName = "Dada",
				Gender = "Male",
				Sport = "Football",
				Level = "Basic_2"
			});
			context.Students.Add(new Student
			{
				Id = 2,
				FirstName = "Toke",
				LastName = "Dada",
				Gender = "Female",
				Sport = "Football",
				Level = "Basic_2"
			});
			context.Students.Add(new Student
			{
				Id = 3,
				FirstName = "Nike",
				LastName = "Dayo",
				Gender = "Female",
				Sport = "Football",
				Level = "Basic_3"
			});

			context.SaveChanges();
		}
	}

}
