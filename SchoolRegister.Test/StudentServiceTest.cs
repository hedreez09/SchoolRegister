using AutoMapper;
using Moq;
using NUnit.Framework;
using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Entities;
using SchoolRegister.DAL.Interface;
using SchoolRegister.Domain;
using SchoolRegister.Domain.ViewModel;
using System.Reflection;

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
			var studentName = "idris Wonuola";
			var student = new StudentViewModel
			{
				Id = 1,
				FullName = studentName,
				Age = 18,
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
		
	}
}
