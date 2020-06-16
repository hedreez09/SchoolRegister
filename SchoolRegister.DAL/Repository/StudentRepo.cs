using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Entities;
using SchoolRegister.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.DAL.Repository
{
    public class StudentRepo : ManagerBase<Student>,IStudentRepo
    {
        
        public StudentRepo(DatabaseContext context):base(context)
        {
           
        }

        public async Task<List<DateTimeOffset>> GetAllStudentsDOB()
        {
            var data = await GetAllAsync();
            var dob = data.Select(s => s.DateOfBirth).ToList();
            return dob;
        }

        public async Task<bool> AddStudent(Student student)
        {
            bool ans = false;
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            Insert(student);
            var stud = CommitAsync();
            ans = await stud > 0;
            return ans;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            bool ans = false;
            var student = GetFirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Remove(student);
                int x = await CommitAsync();
                ans = x > 0;
            }

            return ans;
        }

        public Student GetById(int Id)
        {
            return GetFirstOrDefault(s => s.Id == Id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return GetAll();
        }

        public async Task<bool> UpdateStudent(Student student, int id)
        {
            var std = GetFirstOrDefault(s => s.Id == id);
            if (std == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            std.DateOfBirth = student.DateOfBirth;
            std.FirstName = (string.IsNullOrEmpty(student.FirstName)) ? std.FirstName : student.FirstName;
            std.LastName = (string.IsNullOrEmpty(student.LastName)) ? std.LastName : student.LastName;
            std.Level = student.Level;
            std.Sport = student.Sport;
            std.Gender = student.Gender;
            //var pupil = _mapper.Map<StudenCreationViewModel, Student>(student);
            Update(std);

            var count = await CommitAsync();
            bool res = count > 0;
            return res;
        }
    }
}
