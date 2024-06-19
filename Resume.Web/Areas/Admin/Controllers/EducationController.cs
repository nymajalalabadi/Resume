using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;

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

		public IActionResult List()
		{
			return View();
		}

		#endregion

	}
}
