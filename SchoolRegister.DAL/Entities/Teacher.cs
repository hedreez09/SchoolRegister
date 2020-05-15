using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.DAL.Entities
{
	public class Teacher
	{
		[Key]
		public int TeacherId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Gender { get; set; }
		
		public byte StudentClassId { get; set; }

	}
}
