using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
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
		[Test]
		public void GetStudentIfExist()
		{
			var builder = new DbContextOptionsBuilder<Database>();
			builder.UseSqlite();

		}
		
	}
}
