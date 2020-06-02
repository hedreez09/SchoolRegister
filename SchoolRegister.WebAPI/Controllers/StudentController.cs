using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Domain.ViewModel;
using SchoolRegister.Domain.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolRegister.API.Controllers
{
    [Route("api/students")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService context;

		public StudentController(IStudentService _context)
		{
			context = _context;
		}

		// GET: api/<controller>
		[HttpGet]
		public ActionResult<IEnumerable<StudentViewModel>> GetAll()
		{
			var stds = context.GetStudents();
			if (stds.Count() < 1)
			{
				return NotFound("No Student found");
			}
			return Ok(context.GetStudents());
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
		public ActionResult<StudentViewModel> GetById(int id)
		{
			var std = context.GetStudent(id);
			if (std == null)
			{
				return NotFound($"Student with ID {id} not found");
			}
			return Ok(std);
		}

		[HttpPost]
		public async Task<ActionResult> PostAsync([FromBody]StudenCreationViewModel student)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var age = DateTime.Now.Year - student.DateOfBirth.Year;
			if(!(age >=5 && age <= 20))
			{
				return BadRequest("Date of birth is not within the range limit. Age range is between 5 and 20.");
			}

			bool pupil = await context.AddStudent(student);
			if (pupil)
				return Ok("Student data saved successfully");
			else
				return BadRequest("Something went wrong, data not saved");
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> PutAsync(int id, [FromBody]StudenCreationViewModel student)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (id < 1)
			{
				if(student == null)
					return BadRequest(" Student doest not exist");
				return BadRequest("Only and existing student can be update");
			}
			
			bool pupil = await context.UpdateStudent(id,student);
			if (pupil)
				return Ok(pupil);
			else
				return BadRequest("Something went wrong, data not updated, maybe student not found");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAsync([FromBody]StudentViewModel student)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (student.Id < 1)
			{
				return BadRequest("Invalid Student ID");
			}
			bool pupil = await context.DeleteStudent(student.Id);
			if (pupil)
				return Ok("Student data deleted successfully");
			else
				return BadRequest("Something went wrong, data not deleted, maybe student not found");
		}
	}
}
