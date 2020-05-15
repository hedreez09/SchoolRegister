using SchoolRegister.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.DAL.Interface
{
	public interface ITeacherRepository
	{
		IEnumerable<Teacher> GetTeachers();
		Teacher GetTeacher(int teacherId);
		void AddTeacher(Teacher teacher);
		void UpdateTeacher(Teacher teacher);
		void DeleteTeacher();
	}
}
