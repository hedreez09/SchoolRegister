using AutoMapper;
using SchoolRegister.DAL.Entities;
using SchoolRegister.DAL.Interface;
using SchoolRegister.Domain.Helpers;
using SchoolRegister.Domain.IService;
using SchoolRegister.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Domain
{
    public class StudentService : IStudentService
	{
		private readonly IStudentRepo _studentRepository;
		
		private readonly IMapper _mapper;

		public StudentService(IStudentRepo studentRepository, IMapper mapper)
		{
			_studentRepository = studentRepository;
			_mapper = mapper;
		}


		public async Task<IEnumerable<StudentViewModel>> GetStudents()
        {
			var student = await Task.Run(()=> _studentRepository.GetStudents());
			var response = _mapper.Map<List<Student>, List<StudentViewModel>>(student.ToList());
			return response;
        }

		

		public StudentViewModel GetStudent(int studentId)
        {
			var student = _studentRepository.GetById(studentId);
			if (student == null)
            {
				throw new ArgumentNullException(nameof(student));
			}
			var result = StudentViewModel.ToStudentViewModel(student);
			//(StudentViewModel)student; //_mapper.Map<Student, StudentViewModel>(student);
			return result;
        }

		public async Task<bool> AddStudent(StudentCreationViewModel student)
		{
			bool ans = false;
			var std = StudentCreationViewModel.ToStudent(student);
			ans = await _studentRepository.AddStudent(std);
			return ans;
		}
		

		public async Task<bool> UpdateStudent(StudentCreationViewModel student, int id)
        {
			var std = StudentCreationViewModel.ToStudent(student);
			std.Id = 1;
			//var std = _mapper.Map<StudentCreationViewModel, Student>(student);
			bool result = await _studentRepository.UpdateStudent(std, id);
			return result;
		}

		public async Task<bool> DeleteStudent(int studentId)
        {
			//Delegate to create an anonymous function for a task
			bool ans = await Task.Run(()=> _studentRepository.DeleteStudent(studentId));
			
			return  ans;
		}

		//     public IEnumerable<StudentViewModel> GetAllStudentByLevel(string levelid)
		//     {
		//var student =  _studentRepository.GetAll().Where(x => x.Level == "Level").ToList();
		//if (student == null)
		//{
		//	throw new ArgumentNullException(nameof(student));
		//}
		////var response = _mapper.Map < IEnumerable<StudentViewModel>(student);
		//var response = _mapper.Map<List<Student>, List<StudentViewModel>>(student);
		//return response; throw new NotImplementedException();
		//     }


		public void MarkAttendance(Register register)
        {
            throw new NotImplementedException();
        }

        public void UpdateRegister(Register register)
        {
            throw new NotImplementedException(); 
        }

        public void DeleteRegister(Register register)
        {
            throw new NotImplementedException();
        }

        public double AgeAverage()
        {
			var result = _studentRepository.GetAllStudentsDOB()
										.GetAwaiter()
										.GetResult()
										.GetAverageAge();

			return result;
        }
    }
}
