using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.DAL.DataContext
{
	public class DatabaseContext:DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
		  : base(options)
		{
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Register> Register { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Sport> Sports { get; set; }
		public DbSet<StudentClass> StudentClasses { get; set; }


	}
}
