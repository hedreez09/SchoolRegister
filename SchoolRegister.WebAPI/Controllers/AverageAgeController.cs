using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Domain.IService;
using SchoolRegister.Domain.ViewModel;

namespace SchoolRegister.API.Controllers
{
    [ApiController]
    [Route("api/averageAge")]
    public class AverageAgeController : ControllerBase
    {
        private readonly IStudentService context;

        public AverageAgeController(IStudentService _context)
        {
            context = _context;
        }

        [HttpGet]
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