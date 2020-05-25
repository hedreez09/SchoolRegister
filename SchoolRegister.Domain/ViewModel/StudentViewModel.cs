using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Domain.ViewModel
{
	public class StudentViewModel
	{
		public StudentViewModel()
		{
		}
		public int Id { get; set; }

		[Required(ErrorMessage ="Invalid Full Name")]
		[Display(Name = "Full Name")]
		public string FullName { get; set; }

		
		public int Age { get; set; }

		[Required(ErrorMessage ="Invalid Age")]
		[DataType(DataType.Date)]   
		public DateTimeOffset DateOfBirth { get; set; }

		[Required(ErrorMessage ="Invalid Gender")]
		public string Gender { get; set; }

		public string Sport { get; set; }

		[Required(ErrorMessage ="Invalid level")]
		public string LevelName { get; set; }
	}
}
