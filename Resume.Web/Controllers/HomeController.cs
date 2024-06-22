using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using System.Diagnostics;

namespace Resume.Web.Controllers
{
    public class HomeController : SiteBaseController
    {
		#region Constructor

		private readonly IAboutMeService _aboutMeService;

		public HomeController(IAboutMeService aboutMeService)
		{
			_aboutMeService = aboutMeService;
		}

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var result = await _aboutMeService.GetAboutMeForShowing();

            return View(result);
        }

        #endregion
    }
}
