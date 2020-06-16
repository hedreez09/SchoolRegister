using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Domain.Helpers
{
	public static class DateTimeOffSetExtensions
	{
		//This method help to calculate the current age p
		public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
		{
			var currentDate = DateTime.UtcNow;
			int age = currentDate.Year - dateTimeOffset.Year;

			if (currentDate < dateTimeOffset.AddYears(age))
			{
				age--;
			}

			return age;
		}
		public static double GetAverageAge(this List<DateTimeOffset> date)
        {
			double avg;
			int totalage = 0;
			var myTask = Task.Run(() =>
			{
				foreach (var d in date)
				{
					totalage += d.GetCurrentAge();
				}
			});

			Task.WaitAll(myTask);
			avg = totalage / date.Count;

			return avg;
        } 
	}
}
