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

            return View();
        }

        #endregion
    }
}
