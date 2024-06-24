using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.Experience;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ExperienceController : AdminBaseController
    {
        #region Constructor

        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService) 
        {
            _experienceService = experienceService;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<IActionResult> List(FilterExperienceViewModel filter)
        {
            var result = await _experienceService.FilterExperience(filter);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExperienceViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _experienceService.CreateExperience(create);

            switch (result)
            {
                case CreateExperienceResult.Success:
                    TempData[SuccessMessage] = " تجربه کاری شما با موفقیت ثبت شد.";
                    return RedirectToAction("List");

                case CreateExperienceResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var experience = await _experienceService.GetEditExperienceById(id);

            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditExperienceViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _experienceService.EditExperience(edit);

            switch (result)
            {
                case EditExperienceResult.Success:
                    TempData[SuccessMessage] = " تجربه کاری شما با موفقیت ثبت شد.";
                    return RedirectToAction("List");

                case EditExperienceResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;

                case EditExperienceResult.ExperienceNotFound:
                    TempData[ErrorMessage] = " تجربه کاری  مورد نظر شما پیدا نشد.";
                    break;
            }

            return View(edit);
        }

        #endregion
    }
}
