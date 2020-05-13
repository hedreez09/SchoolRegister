using SchoolRegister.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.DAL.Interface
{
	public interface IStudentRepository
	{
		IEnumerable<Student> GetStudents(int teacherId);
		Student GetStudent(int Id);
		void AddStudent(int Teacher, Student student);
		void UpdateStudent(int Teacher, Student student);
		void DeleteStudent(Student student);
		
		void UpdateRegister(Register register);
		void DeleteRegister(Register register);
		bool Save();
	}
}
