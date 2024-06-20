using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.Education;

namespace Resume.Web.Areas.Admin.Controllers
{
	public class EducationController : AdminBaseController
	{
		#region Constructor

		private readonly IEducationService _educationService;

		public EducationController(IEducationService educationService)
		{
			_educationService = educationService;
		}

		#endregion

		#region Actions

		[HttpGet]
		public async Task<IActionResult> List(FilterEducationViewModel filter)
		{
			return View();
		}
        

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEducationViewModel create)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EditEducationViewModel edit)
        {
            return View();
        }

        #endregion

    }
}
