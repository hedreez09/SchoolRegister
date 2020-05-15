using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.DAL.Entities
{
	public class StudentClass
	{
		public byte StudentClassId { get; set; }		
		public string Level { get; set; }
		public int Teacher { get; set; }
	}
}
