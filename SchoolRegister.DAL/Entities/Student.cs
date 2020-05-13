using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SchoolRegister.DAL.Entities
{
	public class Student
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTimeOffset DateOfBirth { get; set; }
		public byte GenderId { get; set; }
		public Gender Gender { get; set; }
		public byte SportId { get; set; }
		public Sport Sport { get; set; }
		public byte ClassId { get; set; }
		public StudentClass	 StudentCalss { get; set; }
	}
}
