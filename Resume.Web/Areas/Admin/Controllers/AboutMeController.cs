using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class AboutMeController : Controller
    {
        #region Constructor

        private readonly IAboutMeService _aboutMeService;

        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        #endregion


        #region Actions

        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}
