using Moq;
using NUnit.Framework;
using SchoolRegister.Domain.Interface;
using SchoolRegister.Domain.Repository;
using SchoolRegister.Domain.ViewModel;

namespace SchoolRegister.Test
{
	[TestFixture]
	public class StudentRepositoryTest
	{

		[Test]
		public void GetStudentShouldReturnWhenExist()
		{
			var mockIStudentRepository = new Mock<IStudentRepository>();
			var student = new StudentViewModelSave();


			//var sut = new StudentRepository()
			//mockIStudentRepository.Setup(p => p.GetStudent(2)).Returns(2);

			
		}
	}
}
