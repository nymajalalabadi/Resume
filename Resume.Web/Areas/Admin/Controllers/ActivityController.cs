using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.Activity;

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

        #region Actions

        public async Task<IActionResult> List(FilterActivityViewModel filter)
        {
            var result = await _activityService.filterActivityViewModel(filter);

            return View(result);
        }

        #endregion
    }
}
