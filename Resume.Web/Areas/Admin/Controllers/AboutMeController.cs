using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.AboutMe;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class AboutMeController : AdminBaseController
    {
        #region Constructor

        private readonly IAboutMeService _aboutMeService;

        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        #endregion


        #region Actions

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var result = await _aboutMeService.FillCreateOrEditAboutMe();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateOrEditAboutMeViewModel createOrEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(createOrEdit);
            }

            var result = await _aboutMeService.CreateOrEditAboutMe(createOrEdit);

            if (result == true)
            {
                TempData[SuccessMessage] = "ویرایش درباره من با موفقیت انجام شد.";
                return RedirectToAction(nameof(Edit));
            }

            TempData[ErrorMessage] = "خطایی رخ داده است لطفا مجدد تلاش کنید.";
            return RedirectToAction(nameof(Edit));
        }

        #endregion
    }
}
