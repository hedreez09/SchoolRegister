using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.Interface;
using SchoolRegister.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolRegister.Domain.Repository
{
	public class StudentRepository : IStudentRepository

	{
		private readonly DatabaseContext _context;

		public StudentRepository(DatabaseContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async void AddStudent(StudentViewModelSave student)
		{
			if (student == null)
			{
				throw new ArgumentNullException(nameof(student));
			}

			var Std = new Student
			{
				DateOfBirth = student.DateOfBirth,
				FirstName = student.FirstName,
				Gender = student.Gender,
				LastName = student.LastName,
				Level = student.Level,
				Sport = student.Sport
			};
			_context.Students.Add(Std);
			await _context.SaveChangesAsync();
		}

		public void DeleteRegister(Register register)
		{
			_context.Register.Remove(register);
		}

		public async void DeleteStudent(int student)
		{
			var std = _context.Students.FirstOrDefault(c => c.Id == student);
			if (std != null)
			{
				_context.Students.Remove(std);
				await _context.SaveChangesAsync();
			}
		}

		public StudentViewModel GetStudent(int studentId)
		{
			return (from S in _context.Students
					where S.Id == studentId
					select new StudentViewModel
					{
						DateOfBirth = S.DateOfBirth,
						Gender = S.Gender,
						FullName = S.LastName + " " + S.FirstName,
						Id = S.Id,
						LevelName = _context.StudentClasses.FirstOrDefault(x => x.StudentClassId == S.Level).Level,
						Sport = S.Sport,
						Age = DateTime.Now.Year - S.DateOfBirth.Year
					}).FirstOrDefault();

		}

		public IEnumerable<StudentViewModel> GetStudents(int level)
		{

			return (from S in _context.Students
					where S.Level == level
					select new StudentViewModel
					{
						DateOfBirth = S.DateOfBirth,
						Gender = S.Gender,
						FullName = S.LastName + " " + S.FirstName,
						Id = S.Id,
						LevelName = _context.StudentClasses.FirstOrDefault(x => x.StudentClassId == S.Level).Level,
						Sport = S.Sport,
						Age = DateTime.Now.Year - S.DateOfBirth.Year
					}).ToList();
		}

		public IEnumerable<StudentViewModel> GetStudents()
		{

			return (from S in _context.Students
					select new StudentViewModel
					{
						DateOfBirth = S.DateOfBirth,
						Gender = S.Gender,
						FullName = S.LastName + " " + S.FirstName,
						Id = S.Id,
						LevelName = _context.StudentClasses.FirstOrDefault(x => x.StudentClassId == S.Level).Level,
						Sport = S.Sport,
						Age = DateTime.Now.Year - S.DateOfBirth.Year
					}).ToList();
		}

		public void UpdateRegister(Register register)
		{

		}

		public async void UpdateStudent(StudentViewModelSave student)
		{

			if (student == null)
			{
				throw new ArgumentNullException(nameof(student));
			}

			var std = _context.Students.FirstOrDefault(x => x.Id == student.Id);
			if (std != null)
			{
				std.FirstName = student.FirstName;
				std.FirstName = student.LastName;
				std.DateOfBirth = student.DateOfBirth;
				std.Gender = student.Gender;
				std.Sport = student.Sport;
				std.Level = student.Level;
				await _context.SaveChangesAsync();
			}
		}




		public async void MarkAttendance(Register register)
		{
			if (register != null)
			{
				_context.Register.Add(register);
				await _context.SaveChangesAsync();
			}
		}
	}
}