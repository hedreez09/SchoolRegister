using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Domain.IService
{
   public  interface IStudentService
    {
		IEnumerable<StudentViewModel> GetAllStudentByLevel(string levelid);
		IEnumerable<StudentViewModel> GetStudents();
		StudentViewModel GetStudent(int studentId);
		Task<bool> AddStudent(StudenCreationViewModel student);
		Task<Student> UpdateStudent(StudenCreationViewModel student, int id);

		Task<bool> DeleteStudent(int student);
		void MarkAttendance(Register register);
		void UpdateRegister(Register register);
		void DeleteRegister(Register register);
		int AgeAverage();

	}
}
