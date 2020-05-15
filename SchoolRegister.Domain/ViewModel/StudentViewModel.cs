using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.Domain.ViewModel
{
	public class StudentViewModel
	{
		public int Id { get; set; }

		public string FullName { get; set; }

		public int Age { get; set; }

		public DateTimeOffset DateOfBirth { get; set; }

		public string Gender { get; set; }

		public string Sport { get; set; }

		public string LevelName { get; set; }

	}

	public class StudentViewModelSave
	{
		public int Id { get; set; }

		[Required(ErrorMessage ="Invalid First Name")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Invalid Last Name")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required(ErrorMessage ="Invalid Date of Birth")]
		[DataType(DataType.Date)]
		public DateTimeOffset DateOfBirth { get; set; }

		[Required(ErrorMessage ="Invalid Gender")]
		public string Gender { get; set; }

		public string Sport { get; set; }

		[Required(ErrorMessage ="Invalid level")]
		public int Level { get; set; }
	}

}
