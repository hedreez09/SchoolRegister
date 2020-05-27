using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Domain.Repository
{
	public class StudentRepository : DbContext, IDisposable

	{
		private readonly DatabaseContext _context;
		 
		//private IStudentRepository @object;

		public StudentRepository(DatabaseContext context)
		{
			_context = context;//?? throw new ArgumentNullException(nameof(context));
			
		}

		
		public async Task<bool> AddStudent(Student student)
		{
			if (student == null)
			{
				throw new ArgumentNullException(nameof(student));
			}

			_context.Students.Add(student);
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

		public Student GetStudent(int studentId)
		{
			if(studentId < 0)
			{
				throw new ArgumentNullException(nameof(studentId));
			}
			return _context.Students.FirstOrDefault(a => a.Id == studentId)
			//return (from S in _context.Students
			//		where S.Id == studentId
			//		select new StudentViewModel
			//		{
			//			DateOfBirth = S.DateOfBirth,
			//			Gender = S.Gender,
			//			FullName = S.LastName + " " + S.FirstName,
			//			Id = S.Id,
			//			LevelName = S.Level,
			//			Sport = S.Sport,
			//			Age = DateTime.Now.Year - S.DateOfBirth.Year
			//		}).FirstOrDefault();
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

		public IEnumerable<Student> GetStudents()
		{

			return _context.Students.ToList<Student>();
			//return (from S in _context.Students
			//		select new StudentViewModel
			//		{
			//			DateOfBirth = S.DateOfBirth,
			//			Gender = S.Gender,
			//			FullName = S.LastName + " " + S.FirstName,
			//			Id = S.Id,
			//			LevelName = S.Level,
			//			Sport = S.Sport,
			//			Age = DateTime.Now.Year - S.DateOfBirth.Year
			//		}).ToList();
		}

		public void UpdateRegister(Register register)
		{

		}

		public async Task<bool> UpdateStudent(StudenCreationViewModel student)
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