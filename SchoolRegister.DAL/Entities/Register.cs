using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.DAL.Entities
{
	public class Register
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int TeacherId { get; set; }
		public bool Present { get; set; }
	}
}
