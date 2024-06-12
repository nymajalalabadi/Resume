using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Generators;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Areas.Admin.Components
{
    public class LeftSideBarViewComponent : ViewComponent
    {
        #region Constructor

        private readonly IUserService _userService;

        public LeftSideBarViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["User"] = await _userService.GetInfromation(User.GetUserId());

            return View("LeftSideBar");
        }

        #endregion

    }
}
