using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.User;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        #region Constructor

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
             _userService = userService;
        }

        #endregion

        #region Actions

        #region List Of Users

        public async Task<IActionResult> List(FilterUserViewModel filter)
        {
            var result = await _userService.FilterAsync(filter);

            return View(result);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel create)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            var result = await _userService.CreateUser(create);

            switch (result)
            {
                case CreateUserResult.Success:
                    TempData[SuccessMessage] = "کاربر جدید با موفقیت افزوده شد.";
                    return RedirectToAction("List");

                case CreateUserResult.EmailExists:
                    TempData[ErrorMessage] = "خطایی رخ داده است.";
                    break;
            }

            return View(create);
        }

        #endregion

        #region Update

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _userService.GetForEditById(id);

            if (user == null) 
            { 
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditUserViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            var result = await _userService.EditUser(edit);

            switch (result)
            {
                case EditUserResult.Success:
                    TempData[SuccessMessage] = "کاربر با موفقیت ویرایش شد.";
                    return RedirectToAction("List");

                case EditUserResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است.";
                    break;

                case EditUserResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربری پیدار نشد.";
                    break;

                case EditUserResult.EmailDuplicated:
                    TempData[ErrorMessage] = "ایمیل تکراری است.";
                    break;

                case EditUserResult.MobileDuplicated:
                    TempData[ErrorMessage] = "شماره موبایل تکراری است.";
                    break;
            }
            return View(edit);
        }

        #endregion

        #endregion
    }
}
