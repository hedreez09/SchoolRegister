using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Domain.Interface;
using SchoolRegister.Domain.ViewModel;

namespace SchoolRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AverageAgeController : ControllerBase
    {
        private readonly IStudentRepository context;

        public AverageAgeController(IStudentRepository _context)
        {
            context = _context;
        }
        public ActionResult<AvergareAgeViewModel> Get()
        {
            var age = context.AgeAverage();
            AvergareAgeViewModel averageAge = new AvergareAgeViewModel
            {
                AverageAge = age
            };
            return Ok(averageAge);
        }
    }
}