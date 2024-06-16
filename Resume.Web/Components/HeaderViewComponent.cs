using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Components
{
	public class HeaderViewComponent : ViewComponent
	{
        #region Constructor

        private readonly IAboutMeService _aboutMeService;

        public HeaderViewComponent(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var model = await _aboutMeService.GetAboutMeForShowing();

			return View("Header", model);
		}

		#endregion

	}
}
