using AutoMapper;
using Moq;
using NUnit.Framework;
using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Entities;
using SchoolRegister.DAL.Interface;
using SchoolRegister.Domain;
using SchoolRegister.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;
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
		[Test]
		public void GetStudentById_ShouldReturnStudent_whenExist()
		{
			// Arrange
			var stud = new Student();
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
			var expectedStudent = 3;

			Assert.That(expectedStudent, Is.EqualTo(studentViewModel.Count()));
		}

		[Test]
		public void AddingNewStudent()
        {
			var newStudent = new Student()
			{
				FirstName = "Emma",
				LastName = "Nwankwo",
				Gender = "male",
				Sport = "Football",
				Level = "basic5",
				//DateOfBirth = GetCurrentAge()
			};

			//var stud = _studentRepositoryMock.Setup(s => s.AddStudent(newStudent));

			//var stud = new Student(); 

			//Assert.IsTrue(stud);

		}
	}
}
