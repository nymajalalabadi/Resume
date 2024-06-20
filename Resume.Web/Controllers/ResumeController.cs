using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Controllers
{
    public class ResumeController : SiteBaseController
    {
        #region Constructor

        private readonly IEducationService _educationService;

        public ResumeController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        #endregion

        #region Actions

        [HttpGet("/resume")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        #endregion
    }
}
