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
            return View();
        }

        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
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
                    break;
                case CreateUserResult.EmailExists:
                    break;
                default:
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
                    break;
                case EditUserResult.Error:
                    break;
                case EditUserResult.UserNotFound:
                    break;
                case EditUserResult.EmailDuplicated:
                    break;
                case EditUserResult.MobileDuplicated:
                    break;
                default:
                    break;
            }

            return View(edit);
        }

        #endregion

        #endregion
    }
}
