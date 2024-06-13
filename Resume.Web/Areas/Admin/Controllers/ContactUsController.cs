using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Web.Areas.Admin.Controllers
{
	public class ContactUsController : AdminBaseController
	{
		#region Constructor

		private readonly IContactUsService _contactUsService;

		public ContactUsController(IContactUsService contactUsService)
		{
			_contactUsService = contactUsService;
		}

        #endregion

        #region Actions

        [HttpGet]
        public async Task<IActionResult> List(FilterContactUsViewModel model)
		{
			model.TakeEntity = 2;

			return View(await _contactUsService.FilterContactUs(model));
		}

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var contactUs = await _contactUsService.GetContactUsById(id);

            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        [HttpPost]
        public async Task<IActionResult> Details(ContactUsDetailsViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _contactUsService.AnswerContactUs(model);
            switch (result)
            {
                case AnswerResult.Success:
                    TempData[SuccessMessage] = "پاسخ برای این تماس با ما ارسال شد.";
                    return RedirectToAction("List");

                case AnswerResult.ContactUsNotFound:
                    TempData[ErrorMessage] = "تماس با ما پیدا نشد.";
                    break;

                case AnswerResult.AnswerIsNull:
                    TempData[ErrorMessage] = "متن پاسخ خالی است.";
                    break;

            }

            return View(model);
        }

        #endregion
    }
}
