using SchoolRegister.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.DAL.Interface
{
     public interface IStudentRepo
    {
        Student GetById(int Id);
        IEnumerable<Student> GetStudents();

     
        Task<bool> AddStudent(Student student);
        Task<bool> UpdateStudent(Student student, int id);

        Task<bool> DeleteStudent(int id);

        Task<List<DateTimeOffset>> GetAllStudentsDOB();
    }
}
