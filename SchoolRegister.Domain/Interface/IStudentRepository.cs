using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.Domain.Interface
{
	public interface IStudentRepository
	{
		IEnumerable<StudentViewModel> GetStudents(int levelid);
		IEnumerable<StudentViewModel> GetStudents();
		StudentViewModel GetStudent(int studentId);
		void AddStudent(StudentViewModelSave student);
		void UpdateStudent(StudentViewModelSave student);
		void DeleteStudent(int student);
		void MarkAttendance(Register register);
		void UpdateRegister(Register register);
		void DeleteRegister(Register register);
	}
}
