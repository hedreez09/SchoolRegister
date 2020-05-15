using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Domain.ViewModel
{
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
		public string Level { get; set; }
	}
}
