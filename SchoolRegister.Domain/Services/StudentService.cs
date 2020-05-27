using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.Interface;
using SchoolRegister.Domain.Repository;
using SchoolRegister.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Domain
{
	public class StudentService :DbContext,IStudentRepository
	{
		private readonly StudentRepository _studentRepository;
		private readonly DatabaseContext _context;
		private readonly IMapper _mapper;

		public StudentService(StudentRepository studentRepository, DatabaseContext context)
		{
			_studentRepository = studentRepository;
			_context = context;
		}

		public async Task<bool> AddStudent(StudenCreationViewModel student)
		{
			if (student == null)
			{
				throw new ArgumentNullException(nameof(student));
			}

			var Std = new Student
			{
				DateOfBirth = student.DateOfBirth,
				FirstName = student.FirstName,
				LastName = student.LastName,
				Gender = student.Gender,
				Level = student.Level,
				Sport = student.Sport
			};
			await _studentRepository.AddStudent(Std);

			try
			{
				int x = await _studentRepository.SaveChangesAsync();
				return x > 0;
			}
			catch
			{
				//log excemption
				return  false;
			}
		}

		public double AgeAverage()
		{
			throw new NotImplementedException();
		}

		public void DeleteRegister(Register register)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> DeleteStudent(int studentid)
		{
			bool Answer = false;
			var std = new Student();
			var std = _studentRepository.Students.FirstOrDefault(c => c.Id == studentid);
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
			return _studentRepository.GetStudent(1);
		}

		public IEnumerable<StudentViewModel> GetStudents()
		{
			return _studentRepository.GetStudents().Cast<StudentViewModel>();
		}

		public IEnumerable<StudentViewModel> GetStudents(string levelid)
		{
			throw new NotImplementedException();
		}

		public void MarkAttendance(Register register)
		{
			throw new NotImplementedException();
		}

		public void UpdateRegister(Register register)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateStudent(StudenCreationViewModel student)
		{
			throw new NotImplementedException();
		}
	}
}
