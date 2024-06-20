using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Components
{
	public class EducationViewComponent : ViewComponent 
	{
		#region Constructor

		private readonly IEducationService _educationService;

		public EducationViewComponent(IEducationService educationService)
		{
			_educationService = educationService;
		}

		#endregion

		#region Method

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _educationService.GetAllEducationViewModel();

			return View("Education", model);
		}

		#endregion
	}
}
