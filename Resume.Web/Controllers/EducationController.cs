using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Controllers
{
	public class EducationController : SiteBaseController
	{
		#region Constructor

		private readonly IEducationService _educationService;

		public EducationController(IEducationService educationService)
		{
			_educationService = educationService;
		}

		#endregion

		public IActionResult Index()
		{
			return View();
		}
	}
}
