using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Domain.Interface;
using SchoolRegister.Domain.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolRegister.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentRepository context;

		public StudentController(IStudentRepository _context )
		{
			context = _context;
		}
		// GET: api/<controller>
		[HttpGet]
		public IEnumerable<StudentViewModel> Get()
		{
			
			return context.GetStudents(); 
		}

		//// GET: api/<controller>
		//[HttpGet]
		//public IEnumerable<StudentViewModel> AllStudentsByLevel(int level)
		//{
		//	var stds = context.GetStudents(level);
		//	return stds;
		//}
		// GET api/<controller>/5
		[HttpGet("{id}")]
		public StudentViewModel Get(int id)
		{
			var std = context.GetStudent(id);
			return std;
		}
	}
}
