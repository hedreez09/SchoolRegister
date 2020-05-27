using Microsoft.EntityFrameworkCore.Storage;
using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Domain.Interface
{
	public interface IStudentRepository
	{
		IEnumerable<StudentViewModel> GetStudents(string levelid);
		IEnumerable<StudentViewModel> GetStudents();
		StudentViewModel GetStudent(int studentId);
		Task<bool> AddStudent(StudenCreationViewModel student);
		Task<bool> UpdateStudent(StudenCreationViewModel student);
		Task<bool> DeleteStudent(int student);
		void MarkAttendance(Register register);
		void UpdateRegister(Register register);
		void DeleteRegister(Register register);
		double AgeAverage();
	}
}
