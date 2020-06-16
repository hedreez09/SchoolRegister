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
			var stds = context.GetStudents().GetAwaiter().GetResult();
			if (stds.Count() < 0 )
			{
				return NotFound("No Student found");
			}
			return Ok(stds);
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
		public async Task<ActionResult> PostAsync([FromBody]StudentCreationViewModel student)
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
		public async Task<ActionResult> PutAsync(int id, [FromBody]StudentCreationViewModel student)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (student == null)
				return BadRequest(" Student doest not exist");

			//student.Id = id;

			var pupil = await context.UpdateStudent(student,id);
			return Ok(pupil);
			
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAsync(int id)
		{
			if (id < 1)
			{
				return BadRequest("Invalid Student ID");
			}
			
			bool pupil = await context.DeleteStudent(id);
			if (pupil)
				return Ok("Student data deleted successfully");
			else
				return BadRequest("Something went wrong, data not deleted, maybe student not found");
		}
	}
}
