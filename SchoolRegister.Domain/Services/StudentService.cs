using AutoMapper;
using SchoolRegister.DAL.Entities;
using SchoolRegister.DAL.Interface;
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
		private readonly IRepository<Student> _studentRepository;
		
		private readonly IMapper _mapper;

		public StudentService(IRepository<Student> studentRepository, IMapper mapper)
		{
			_studentRepository = studentRepository;
			_mapper = mapper;
		}


		public async Task<IEnumerable<StudentViewModel>> GetStudents()
        {
			var student = await _studentRepository.GetAllAsync();
			var response = _mapper.Map<List<Student>, List<StudentViewModel>>(student);
			return response;
        }

		public async Task<IEnumerable<StudentViewModel>> GetStudentsBylevel()
		{
			var student = await _studentRepository.GetAllAsync(x => x.Level == "Level");
			if (student == null)
            {
				throw new ArgumentNullException(nameof(student));
			}
			var response = _mapper.Map<List<Student>, List<StudentViewModel>>(student);
			return response;
		}

		public StudentViewModel GetStudent(int studentId)
        {
			var student = _studentRepository.GetFirstOrDefault(s => s.Id == studentId);
			if (student == null)
            {
				throw new ArgumentNullException(nameof(student));
			}
			var result = _mapper.Map<Student, StudentViewModel>(student);
			return result;
        }

		public async Task<bool> AddStudent(StudenCreationViewModel student)
		{
			bool ans = false;
			var std = _mapper.Map<StudenCreationViewModel, Student>(student);
			if (std == null)
			{
				throw new ArgumentNullException(nameof(student));
			}
			_studentRepository.Insert(std);
			var stud = await _studentRepository.CommitAsync();
			ans = stud > 0;
			return ans;
		}
		

		public async Task<bool> UpdateStudent(int studentId, StudenCreationViewModel student)
        {
			bool ans = false;
			var std = _studentRepository.GetFirstOrDefault(s => s.Id == studentId);
			if(std == null)
            {
				throw new ArgumentNullException(nameof(studentId));
			}

			//var pupil = _mapper.Map<StudenCreationViewModel, Student>(student);
			_studentRepository.Update(std,student);

			
			int stud = await _studentRepository.CommitAsync();
			ans = stud > 0;
			return ans ;
		}

		public async Task<bool> DeleteStudent(int studentId)
        {
			bool ans = false;
			var student = _studentRepository.GetFirstOrDefault(s => s.Id == studentId);
			if(student != null)
            {
				//student.IsDeleted = true;
				//_studentRepository.Update(student);

				_studentRepository.Remove(student);
				int x = await _studentRepository.CommitAsync();
				ans = x > 0;
			}
			//ans = true;
			return  ans;
		}

        public IEnumerable<StudentViewModel> GetAllStudentByLevel(string levelid)
        {
			var student =  _studentRepository.GetAll().Where(x => x.Level == "Level").ToList();
			if (student == null)
			{
				throw new ArgumentNullException(nameof(student));
			}
			//var response = _mapper.Map < IEnumerable<StudentViewModel>(student);
			var response = _mapper.Map<List<Student>, List<StudentViewModel>>(student);
			return response; throw new NotImplementedException();
        }

        IEnumerable<StudentViewModel> IStudentService.GetStudents()
        {
			var student = _studentRepository.GetAll().ToList();
			var response = _mapper.Map<IEnumerable<StudentViewModel>>(student);
			return response;
		}

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

  //      public double AgeAverage()
		//{  
		//	var age = _studentRepository.Average(age);
		//	return 
		//}
    }
}
