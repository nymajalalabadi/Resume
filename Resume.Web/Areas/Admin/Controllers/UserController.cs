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

            return View();
        }

        #endregion

        #region Update

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditUserViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            return View();
        }

        #endregion

        #endregion
    }
}
