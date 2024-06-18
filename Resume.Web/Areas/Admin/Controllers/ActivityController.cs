using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
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
            if (!ModelState.IsValid)
            {
                return View(create);
            }
            var result = await _activityService.CreateActivity(create);

            switch (result)
            {
                case CreateActivityResult.Success:
                    TempData[SuccessMessage] = "فعالیت جدید با موفقیت ثبت شد.";
                    return RedirectToAction("List");

                case CreateActivityResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
            }
            return View(create);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var activity = await _activityService.GetActivityById(id);

            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditActivityViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }
            var result = await _activityService.EditActivity(edit);

            switch (result)
            {
                case EditActivityResult.Success:
                    TempData[SuccessMessage] = "ویرایش فعالیت  با موفقیت ثبت شد";
                    return RedirectToAction("List");

                case EditActivityResult.Error:
                    TempData[ErrorMessage] = "فعالیت شما با مشکل رو به رو شد";
                    break;
                case EditActivityResult.ActivityNotFound:
                    TempData[ErrorMessage] = "فعالیت شما پیدا نشد.";
                    break;
            }

            return View(edit);
        }

        #endregion
    }
}
