using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Components
{
    public class LeftSideBarViewComponent : ViewComponent
    {
        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LeftSideBar");
        }

        #endregion

    }
}
