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

        [HttpGet]
        public async Task<IActionResult> List(FilterActivityViewModel filter)
        {
            var result = await _activityService.filterActivityViewModel(filter);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActivityViewModel create)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(EditActivityViewModel edit)
        {
            return View();
        }

        #endregion
    }
}
