using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.Skil;

namespace Resume.Web.Areas.Admin.Controllers
{
	public class SkilController : AdminBaseController
	{
		#region Constructor

		private readonly ISkilService _skilService;

		public SkilController(ISkilService skilService)
		{
			_skilService = skilService;
		}

		#endregion

		#region Actions

		[HttpGet]
		public async Task<IActionResult> List(FilterSkilViewModel filter)
		{
			var result = await _skilService.FilterSkil(filter);

			return View(result);
		}

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkilViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _skilService.CreateSkil(create);

            switch (result)
            {
                case CreateSkilResult.Success:
                    TempData[SuccessMessage] = "مهارت شما با موفقیت ثبت شد.";
                    return RedirectToAction("List");

                case CreateSkilResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var skil = await _skilService.GetEditSkilById(id);

            if (skil == null)
            {
                return NotFound();
            }

            return View(skil);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditSkilViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _skilService.EditSkil(edit);

            switch (result)
            {
                case EditSkilResult.Success:
                    TempData[SuccessMessage] = "مهارت شما با موفقیت ثبت شد.";
                    return RedirectToAction("List");

                case EditSkilResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;

                case EditSkilResult.SkilNotFount:
                    TempData[ErrorMessage] = "مهارت  مورد نظر شما پیدا نشد.";
                    break;
            }

            return View(edit);
        }

        #endregion
    }
}
