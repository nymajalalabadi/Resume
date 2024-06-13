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

		public async Task<IActionResult> List(FilterContactUsViewModel model)
		{
			model.TakeEntity = 2;

			return View(await _contactUsService.FilterContactUs(model));
		}

		#endregion
	}
}
