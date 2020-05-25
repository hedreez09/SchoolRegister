using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SchoolRegister.DAL.DataContext;
using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.Interface;
using SchoolRegister.Domain.Repository;
using SchoolRegister.Domain.ViewModel;
using SchoolRegister.Test.MockData;
using System.Threading.Tasks;

namespace SchoolRegister.Test
{
	[TestFixture]
	public class StudentRepositoryTest
	{
		private readonly DatabaseContext _data;

//		[Test]
//		public void GetStudentIfExist()
//		{
//			var mockIstudentRepository = new Mock<IStudentRepository>()
//;			var sut = new StudentRepository(_data);
//			var std = new StudentViewModel()
//			{
//				Id = 1,
//				FullName = "idris Ola",
//				Gender = "Male",
//				Sport = "Tennis",
//				LevelName = "baisc_1",
//				Age = 8
//			};

//			//mockIstudentRepository.Setup(s => s.GetStudent(10)).(1);

//			sut.GetStudent(10);
//			Assert.IsNotNull(std);
//			//Assert.That()
//		}
		
	}
}
