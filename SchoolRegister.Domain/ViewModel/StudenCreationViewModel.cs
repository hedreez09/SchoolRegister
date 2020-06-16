using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolRegister.Domain.ViewModel
{
	public class StudentCreationViewModel
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
		[Display(Name = "Gender")]
		public string Gender { get; set; }

		public string Sport { get; set; }

		[Required(ErrorMessage = "Invalid level")]
		public string Level { get; set; }


		public static explicit operator Student(StudentCreationViewModel student)
		{
			return new Student
			{
				DateOfBirth = student.DateOfBirth,	
				FirstName = student.FirstName,
				LastName = student.LastName,
				Sport = student.Sport,
				Gender = student.Gender,
				Level = student.Level

			};
		}

		//When converting to student entity
		public static Student ToStudent(StudentCreationViewModel student)
		{
			_ = student ?? throw new ArgumentNullException(nameof(student));

			return new Student
			{
				FirstName = student.FirstName,
				LastName = student.LastName,
				Gender = student.Gender,
				Sport = student.Sport,
				DateOfBirth = student.DateOfBirth,
				Level = student.Level
			};
		}


		public static StudentCreationViewModel ToStudentCreationViewModel(Student student)
		{
			//This is to check if the object is not null so as not to break later 
			_ = student ?? throw new ArgumentNullException(nameof(student));

			return new StudentCreationViewModel
			{
				FirstName = student.FirstName,
				LastName = student.LastName,
				Gender = student.Gender,
				Sport = student.Sport,
				DateOfBirth = student.DateOfBirth,
				Level = student.Level
			};
		}


		
	}

}
