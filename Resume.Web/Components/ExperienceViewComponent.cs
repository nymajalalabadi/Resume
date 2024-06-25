using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Components
{
    public class ExperienceViewComponent : ViewComponent
    {
        #region Constructor

        private readonly IExperienceService _experienceService;

        public ExperienceViewComponent(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _experienceService.GetAllExperienceViewModel();

            return View("Experience", model);
        }

        #endregion
    }
}
