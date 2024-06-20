using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.Education;

namespace Resume.Web.Areas.Admin.Controllers
{
	public class EducationController : AdminBaseController
	{
		#region Constructor

		private readonly IEducationService _educationService;

		public EducationController(IEducationService educationService)
		{
			_educationService = educationService;
		}

		#endregion

		#region Actions

		[HttpGet]
		public async Task<IActionResult> List(FilterEducationViewModel filter)
		{
            var result = await _educationService.FilterEducation(filter);

			return View(result);
		}
        

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEducationViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _educationService.CreateEducation(create);

            switch (result)
            {
                case CreateEducationResult.Success:
                    TempData[SuccessMessage] = " تحصیلات جدید با موفقیت ثبت شد.";
                    return RedirectToAction("List");

                case CreateEducationResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var education = await _educationService.GetEditEducationById(id);

            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EditEducationViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _educationService.EditEducation(edit);

            switch (result)
            {
                case EditEducationResult.Success:
                    TempData[SuccessMessage] = " تحصیلات جدید با موفقیت ثبت شد.";
                    return RedirectToAction("List");

                case EditEducationResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;

                case EditEducationResult.EducationNotFound:
                    TempData[ErrorMessage] = " تحصیلات  مورد نظر شما پیدا نشد.";
                    break;
            }

            return View(edit);
        }

        #endregion

    }
}
