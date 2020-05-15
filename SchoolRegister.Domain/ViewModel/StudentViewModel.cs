using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace SchoolRegister.Domain.ViewModel
{
	public class StudentViewModel
	{
		public int Id { get; set; }

		public string FullName { get; set; }

		public int Age { get; set; }

		public DateTimeOffset DateOfBirth { get; set; }

		public string Gender { get; set; }

		public string Sport { get; set; }

		public string LevelName { get; set; }

	}
}
