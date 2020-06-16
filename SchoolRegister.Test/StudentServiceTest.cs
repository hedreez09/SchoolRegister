using AutoMapper;
using Moq;
using NUnit.Framework;
using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Entities;
using SchoolRegister.DAL.Interface;
using SchoolRegister.Domain;
using SchoolRegister.Domain.Helpers;
using SchoolRegister.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace SchoolRegister.Test
{
    [TestFixture]
	public class StudentServiceTest
	{
		private readonly StudentService _sysUnderTest;
		private readonly Mock<IStudentRepo> _studentRepositoryMock = new Mock<IStudentRepo>();
		private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
		public StudentServiceTest()
        {
			_sysUnderTest = new StudentService(_studentRepositoryMock.Object, _mapperMock.Object);

		}
		public  Student GetStud()
        {
			var studentName = "idris";
			var studentName2 = "Wonuola";
			var student = new Student
			{
				Id = 1,
				FirstName = studentName,
				LastName = studentName2,
				Gender = "Male",
				Sport = "Tennis",
				Level = "Basic4",
				DateOfBirth = DateTimeOffset.Parse("2010-03-04")
			};
			return student;
		}
		

		public IEnumerable<StudentViewModel> GetAll()
        {
			IList<StudentViewModel> studentViewModel = new List<StudentViewModel>()
			{
				new StudentViewModel
				{
					Id = 1,
					FullName = "Adeola Adelakun",
					Sport = "Tennis",
					Gender = "Male",
					Age = 20,
					Level = "Basic4"
				},


				new StudentViewModel
				{
					Id = 2,
					FullName = "Adeola Adelakun",
					Sport = "Tennis",
					Gender = "Male",
					Age = 20,
					Level = "Basic4"
				},


				new StudentViewModel
				{
					Id = 3,
					FullName = "AdeTola olalakun",
					Sport = "Tennis",
					Gender = "Male",
					Age = 20,
					Level = "Basic4"
				},
			};

			return studentViewModel;
		}

		[Test]
		public void GetStudentById_ShouldReturnStudent_whenExist()
		{
			// Arrange
			//var stud = new Student();
			var studentName = "idris";
			var studentName2 = 	"Wonuola";
			var student = new Student
			{
				Id = 1,
				FirstName = studentName,
				LastName = studentName2,
				Gender = "Male",
				Sport = "Tennis",
				Level = "Basic4",
				DateOfBirth = DateTimeOffset.Parse("2010-03-04")

			};

			_studentRepositoryMock.Setup(s => s.GetById(student.Id)).Returns(student);
			//Act
			var studenttoCheck = _sysUnderTest.GetStudent(1);

			//Asser;
			Assert.That(studenttoCheck.Id, Is.EqualTo(student.Id));
			Assert.That(studenttoCheck.Gender, Is.EqualTo(student.Gender));
			Assert.That(studenttoCheck.Level, Is.EqualTo(student.Level));
			Assert.That(studenttoCheck.Sport, Is.EqualTo(student.Sport));
		}
		
		[Test]
		public void GetAllStudentThatExist()
        {

			//Arrange
			IList<StudentViewModel> studentViewModel = new List<StudentViewModel>()
			{
				new StudentViewModel
				{
					Id = 1,
					FullName = "Adeola Adelakun",
					Sport = "Tennis",
					Gender = "Male",
					Age = 20,
					Level = "Basic4"
				},


				new StudentViewModel
				{
					Id = 2,
					FullName = "Adeola Adelakun",
					Sport = "Tennis",
					Gender = "Male",
					Age = 20,
					Level = "Basic4"
				},


				new StudentViewModel
				{
					Id = 3,
					FullName = "AdeTola olalakun",
					Sport = "Tennis",
					Gender = "Male",
					Age = 20,
					Level = "Basic4"
				},
			};


			_studentRepositoryMock.Setup(s => s.GetStudents());

			//Act
			var expectedStudent = studentViewModel.Count();

			Assert.That(expectedStudent, Is.EqualTo(studentViewModel.Count()));
		}

		[Test]
		public async Task AddingNewStudent()
        {
			var newStudent = new Student()
			{
				FirstName = "Emma",
				LastName = "Nwankwo",
				Gender = "male",
				Sport = "Football",
				Level = "basic5",
				DateOfBirth =DateTimeOffset.Parse("2010-03-04")
			};

			//var newStudent2 = new Student()
			//{
				
			//	FirstName = "Idris", 
			//	LastName = "Nwankwo",
			//	Gender = "male",
			//	Sport = "Football",
			//	Level = "basic5",
			//	DateOfBirth = DateTimeOffset.Parse("2012-03-04")
			//};
			_studentRepositoryMock.Setup(s => s.AddStudent(newStudent)).ReturnsAsync(true);

			var expectedStud = await _studentRepositoryMock.Object.AddStudent(newStudent);
			//var expectedStud = new Student(); 
			Assert.IsNotNull(newStudent);
			Assert.IsTrue(expectedStud);
		}
		[Test]
		public void GetAverageAgeOfAll()
        {
			//Arrange
			IList<Student> students = new List<Student>()
			{
				new Student
				{
					Id = 1,
					FirstName = "AdeTola",
					LastName = "AdeTola",
					Sport = "Tennis",
					Gender = "Male",
					DateOfBirth = DateTimeOffset.Parse("2010-03-04"),
					Level = "Basic4"
				},


				new Student
				{
					Id = 2,
					FirstName = "AdeTola",
					LastName = "AdeTola",
					Sport = "Tennis",
					Gender = "Male",
					DateOfBirth = DateTimeOffset.Parse("2010-03-04"),
					Level = "Basic4"
				},


				new Student
				{
					Id = 3,
					FirstName = "AdeTola",
					LastName = "AdeTola",
					Sport = "Tennis",
					Gender = "Male",
					DateOfBirth = DateTimeOffset.Parse("2010-03-04"),
					Level = "Basic4"
				},
			};

			List<DateTimeOffset> ages = new List<DateTimeOffset>();

			foreach (var student in students)
            {
				ages.Add(student.DateOfBirth);
            }

			 _studentRepositoryMock.Setup(a => a.GetAllStudentsDOB()).ReturnsAsync(ages);

			//Act
			var expectedAge = _studentRepositoryMock.Object.GetAllStudentsDOB().GetAwaiter()
															.GetResult()
															.GetAverageAge();
			//assert
			Assert.That(expectedAge, Is.EqualTo(10));
		}

		
	}

	
}
