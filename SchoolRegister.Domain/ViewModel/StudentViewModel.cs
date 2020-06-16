using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.Helpers;
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
		public string Level { get; set; }


		//Implicit operation for mapping the entity to viewModel
        public static implicit operator StudentViewModel(Student student)
        {
            return new StudentViewModel
            {
				Id = student.Id,
                Age = student.DateOfBirth.GetCurrentAge(),
                DateOfBirth = student.DateOfBirth,
                FullName = $"{student.FirstName} {student.LastName}",
				Sport = student.Sport,
				Gender = student.Gender,
				Level = student.Level

            };
        }

		public static Student ToStudent(StudentViewModel student)
        {
			_ = student ?? throw new ArgumentNullException(nameof(student));
			var name = student.FullName.Split(new char[0]);
			return new Student
			{
				Id = student.Id,
				FirstName = name[0],
				LastName = name[1],
				Gender =student.Gender,
				Sport = student.Sport,
				DateOfBirth = student.DateOfBirth,
				Level = student.Level
			};
        }

		public static StudentViewModel ToStudentViewModel(Student student)
        {
			return new StudentViewModel
			{
				Id = student.Id,
				Age = student.DateOfBirth.GetCurrentAge(),
				DateOfBirth = student.DateOfBirth,
				FullName = $"{student.FirstName} {student.LastName}",
				Sport = student.Sport,
				Gender = student.Gender,
				Level = student.Level
			};
		}
    }
}
