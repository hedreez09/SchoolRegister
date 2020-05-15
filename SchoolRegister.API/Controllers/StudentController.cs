using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Domain.Interface;
using SchoolRegister.Domain.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolRegister.API.Controllers
{
	[Route("api/[controller]")]
	public class StudentController : Controller
	{
		private readonly IStudentRepository context;

		public StudentController(IStudentRepository _context )
		{
			context = _context;
		}
		// GET: api/<controller>
		[HttpGet]
		public IEnumerable<StudentViewModel> AllStudents()
		{
			
			return context.GetStudents(); 
		}

		// GET: api/<controller>
		[HttpGet]
		public ActionResult<IEnumerable<StudentViewModel>> AllStudentsByLevel(int level)
		{
			var stds = context.GetStudents(level);
			if (stds.Count()<1)
			{
				return NotFound();
			}
			return Ok(stds);
		}
		// GET api/<controller>/5
		[HttpGet("{id}")]
		public ActionResult<StudentViewModel> Student(int id)
		{
			var std = context.GetStudent(id);
			if (std == null)
			{
				return NotFound();
			}
			return Ok(std);
		}

		// POST api/<controller>
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
