using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.DAL.Entities
{
	public class Sport
	{
		public byte SportId { get; set; }
		[Required]
		public string SportName { get; set; }
	}
}
