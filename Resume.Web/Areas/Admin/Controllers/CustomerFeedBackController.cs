using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.Activity;
using Resume.DAL.ViewModels.CustomerFeedBack;

namespace Resume.Web.Areas.Admin.Controllers
{
	public class CustomerFeedBackController : AdminBaseController
	{
		#region Constructor

		private readonly ICustomerFeedBackService _customerFeedBackService;

		public CustomerFeedBackController(ICustomerFeedBackService customerFeedBackService)
		{
			_customerFeedBackService = customerFeedBackService;
		}

		#endregion

		#region Actions

		[HttpGet]
		public async Task<IActionResult> List(FilterCustomerFeedBackViewModel filter)
		{
			var result = await _customerFeedBackService.FilterCustomerFeedBack(filter);

			return View(result);
		}

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerFeedBackViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }
            var result = await _customerFeedBackService.CreateCustomerFeedBack(create);

            switch (result)
            {
                case CreateCustomerFeedBackResult.Success:
                    TempData[SuccessMessage] = "کاربر جدید با موفقیت ثبت شد.";
                    return RedirectToAction("List");

                case CreateCustomerFeedBackResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
            }

            return View(create);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var customer = await _customerFeedBackService.GetCustomerFeedBackById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditCustomerFeedBackViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }
            var result = await _customerFeedBackService.EditCustomerFeedBack(edit);

            switch (result)
            {
                case EditCustomerFeedBackResult.Success:
                    TempData[SuccessMessage] = "ویرایش کاربر با موفقیت ثبت شد";
                    return RedirectToAction("List");

                case EditCustomerFeedBackResult.Error:
                    TempData[ErrorMessage] = "کاربر شما با مشکل رو به رو شد";
                    break;

                case EditCustomerFeedBackResult.CustomerFeedBackNotFound:
                    TempData[ErrorMessage] = "کاربر شما پیدا نشد.";
                    break;
            }

            return View(edit);
        }

        #endregion
    }
}
