using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.DAL.Entities
{
	public class Teacher
	{
		public int TeacherId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public byte GenderId { get; set; }
		public Gender Gender { get; set; }
		

	}
}
