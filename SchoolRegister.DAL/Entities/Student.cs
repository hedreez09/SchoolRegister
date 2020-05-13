using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SchoolRegister.DAL.Entities
{
	public class Student
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public DateTimeOffset DateOfBirth { get; set; }
		[Required]
		public byte GenderId { get; set; }
		public Gender Gender { get; set; }
		[Required]
		public byte SportId { get; set; }
		
		public Sport Sport { get; set; }
		[Required]
		public byte StudentClassId { get; set; }
		public StudentClass	 StudentCalss { get; set; }
	}
}
