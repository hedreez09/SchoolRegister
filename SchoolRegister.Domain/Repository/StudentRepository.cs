using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.Interface;
using SchoolRegister.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SchoolRegister.Domain.Repository
{
	public class StudentRepository : IStudentRepository, IDisposable

	{
		private readonly DatabaseContext _context;

		public StudentRepository(DatabaseContext context)
		{
			_context = context;//?? throw new ArgumentNullException(nameof(context));
		}

		
		public async Task<bool> AddStudent(StudentViewModelSave student)
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
			try
			{
				int x = await _context.SaveChangesAsync();
				return x > 0;
			}
			catch
			{
				//log excemption
				return false;
			}
		}

		public void DeleteRegister(Register register)
		{
			_context.Register.Remove(register);
		}

		public async Task<bool> DeleteStudent(int student)
		{
			bool Answer = false;
			var std = _context.Students.FirstOrDefault(c => c.Id == student);
			if (std != null)
			{
				_context.Students.Remove(std);
				int x = await _context.SaveChangesAsync();
				Answer = x > 0;
			}
			return Answer;
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
						LevelName = S.Level,
						Sport = S.Sport,
						Age = DateTime.Now.Year - S.DateOfBirth.Year
					}).FirstOrDefault();

		}

		public IEnumerable<StudentViewModel> GetStudents(string level)
		{

			return (from S in _context.Students
					where S.Level == level
					select new StudentViewModel
					{
						DateOfBirth = S.DateOfBirth,
						Gender = S.Gender,
						FullName = S.LastName + " " + S.FirstName,
						Id = S.Id,
						LevelName = S.Level,
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
						LevelName = S.Level,
						Sport = S.Sport,
						Age = DateTime.Now.Year - S.DateOfBirth.Year
					}).ToList();
		}

		public void UpdateRegister(Register register)
		{

		}

		public async Task<bool> UpdateStudent(StudentViewModelSave student)
		{
			bool Answer = false;

			var std = _context.Students.FirstOrDefault(x => x.Id == student.Id);
			if (std != null)
			{
				std.FirstName = student.FirstName;
				std.LastName = student.LastName;
				std.DateOfBirth = student.DateOfBirth;
				std.Gender = student.Gender;
				std.Sport = student.Sport;
				std.Level = student.Level;
				int x = await _context.SaveChangesAsync();
				Answer = x > 0;
			}
			return Answer;
		}




		public async void MarkAttendance(Register register)
		{
			if (register != null)
			{
				_context.Register.Add(register);
				await _context.SaveChangesAsync();
			}
		}

		public void Dispose()
		{
			if (_context != null)
				_context.Dispose();
		}

		public double AgeAverage()
		{
			return Convert.ToDouble((from std in _context.Students
									let Age = DateTime.Now.Year - std.DateOfBirth.Year
									select new { Age }).Average(x=>x.Age));
		}
	}
}