using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.CustomerLogo;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class CustomerLogoController : AdminBaseController
    {
        #region Constructor

        private readonly ICustomerLogoService _customerLogoService;

        public CustomerLogoController(ICustomerLogoService customerLogoService)
        {
            _customerLogoService = customerLogoService;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> List(FilterCustomerLogoViewModel filter)
        {
            var result = await _customerLogoService.FilterCustomerLogo(filter);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerLogoViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }
            var result = await _customerLogoService.CreateCustomerLogo(create);

            switch (result)
            {
                case CreateCustomerLogoResult.Success:
                    TempData[SuccessMessage] = "کاربر جدید با موفقیت ثبت شد.";
                    return RedirectToAction("List");

                case CreateCustomerLogoResult.Error:
                    TempData[ErrorMessage] = "خطای رخ داده است";
                    break;
            }

            return View(create);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var customer = await _customerLogoService.GetCustomerLogoById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditCustomerLogoViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }
            var result = await _customerLogoService.EditCustomerLogo(edit);

            switch (result)
            {
                case EditCustomerLogoResult.Success:
                    TempData[SuccessMessage] = "ویرایش کاربر با موفقیت ثبت شد";
                    return RedirectToAction("List");

                case EditCustomerLogoResult.Error:
                    TempData[ErrorMessage] = "کاربر شما با مشکل رو به رو شد";
                    break;

                case EditCustomerLogoResult.CustomerLogoNotFound:
                    TempData[ErrorMessage] = "کاربر شما پیدا نشد.";
                    break;
            }

            return View(edit);
        }

        #endregion
    }
}
