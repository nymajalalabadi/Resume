using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Web.Controllers
{
    public class ContactUsController : SiteBaseController
    {
        #region Constructor

        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        #endregion

        #region Actions

        [HttpGet("contact-us")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost("contact-us")]
        public async Task<IActionResult> ContactUs(CreateContactUsViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _contactUsService.CreateContactUs(create);

            switch (result)
            {
                case CreateContactUsResult.Success:
                    TempData[SuccessMessage] = "پیام شما با موفقیت ثبت شد. نتیجه از طریق ایمیل به شما اطلاع رسانی خواهد شد.";
                    return RedirectToAction("ContactUs");

                case CreateContactUsResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است لطفا مجدد تلاش کنید.";
                    break;
            }

            return View();
        }

        #endregion
    }
}
