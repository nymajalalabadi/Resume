using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Controllers
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

        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        #endregion
    }
}
