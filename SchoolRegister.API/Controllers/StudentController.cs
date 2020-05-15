﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

		public StudentController(IStudentRepository _context)
		{
			context = _context;
		}

	

		// GET: api/<controller>
		[HttpGet]
		public ActionResult<IEnumerable<StudentViewModel>> Get()
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
		public ActionResult<StudentViewModel> Get(int id)
		{
			var std = context.GetStudent(id);
			if (std == null)
			{
				return NotFound($"Student with ID {id} not found");
			}
			return Ok(std);
		}

		[HttpPost]
		public async Task<ActionResult> PostAsync([FromBody]StudentViewModelSave student)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			bool x = await context.AddStudent(student);
			if (x)
				return Ok("Student data saved successfully");
			else
				return BadRequest("Something went wrong, data not saved");
		}
		[HttpPut]
		public async Task<ActionResult> PutAsync([FromBody]StudentViewModelSave student)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (student.Id < 1)
			{
				return BadRequest("Invalid Student ID");
			}
			bool x = await context.UpdateStudent(student);
			if (x)
				return Ok("Student data updated successfully");
			else
				return BadRequest("Something went wrong, data not updated, maybe student not found");
		}

		[HttpDelete]
		public async Task<ActionResult> DeleteAsync([FromBody]StudentViewModelSave student)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (student.Id < 1)
			{
				return BadRequest("Invalid Student ID");
			}
			bool x = await context.DeleteStudent(student.Id);
			if (x)
				return Ok("Student data deleted successfully");
			else
				return BadRequest("Something went wrong, data not deleted, maybe student not found");
		}
	}
}
