using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Domain.ViewModel
{
	public class AvergareAgeViewModel
	{
		[Display(Name = "Average Age")]
		public double AverageAge { get; set; }
	}
}
