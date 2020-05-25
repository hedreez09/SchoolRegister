﻿using System;
using System.Collections.Generic;
using System.Text;

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
	}
}
