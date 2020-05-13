using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.DAL.Entities
{
	public class Gender
	{
		public byte GenderId { get; set; }
		[Required]
		public string GenderType { get; set; }
	}
}
