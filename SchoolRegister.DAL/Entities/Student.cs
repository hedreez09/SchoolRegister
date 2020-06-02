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
	
		public string FirstName { get; set; }
		
		public string LastName { get; set; }
		
		public DateTimeOffset DateOfBirth { get; set; }
		
		public string Gender { get; set; }
		
		public string Sport { get; set; }
		public string Level { get; set; }

        //public bool IsDeleted { get; set; }
    }
}
