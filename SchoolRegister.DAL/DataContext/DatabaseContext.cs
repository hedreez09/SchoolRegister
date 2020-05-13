using Microsoft.EntityFrameworkCore;
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

	}
}
