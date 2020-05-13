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

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public byte GenderId { get; set; }
		public Gender Gender { get; set; }
		[Required]
		public byte StudentClassId { get; set; }
	}
}
