using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.Domain.ViewModel
{
	public class StudenCreationViewModel
	{
		//public int Id { get; set; }
		[Required(ErrorMessage = "Invalid First Name")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Invalid Last Name")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Invalid Date of Birth")]
		[Display(Name = " Date of Birth")]
		public DateTimeOffset DateOfBirth { get; set; }

		[Required(ErrorMessage = "Invalid Gender")]
		[Display(Name ="Gender")]
		public string Gender { get; set; }

		public string Sport { get; set; }

		[Required(ErrorMessage = "Invalid level")]
		public string Level { get; set; }

	}
}
