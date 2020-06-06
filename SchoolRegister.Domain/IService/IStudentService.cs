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
		//IEnumerable<StudentViewModel> GetAllStudentByLevel(string levelid);
		Task<IEnumerable<StudentViewModel>> GetStudents();
		StudentViewModel GetStudent(int studentId);
		Task<bool> AddStudent(StudentCreationViewModel student);
		Task<bool> UpdateStudent(StudentCreationViewModel student, int id);

		Task<bool> DeleteStudent(int student);
		void MarkAttendance(Register register);
		void UpdateRegister(Register register);
		void DeleteRegister(Register register);
		double AgeAverage();

	}
}
