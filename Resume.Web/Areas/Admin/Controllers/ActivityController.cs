using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ActivityController : AdminBaseController
    {
        #region Constructor

        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
