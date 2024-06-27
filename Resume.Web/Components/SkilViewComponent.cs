using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Components
{
    public class SkilViewComponent : ViewComponent
    {
        #region Constructor

        private readonly ISkilService _skilService;

        public SkilViewComponent(ISkilService skilService)
        {
            _skilService = skilService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _skilService.GetAllSkilViewModel();

            return View("Skil", model);
        }

        #endregion
    }
}
