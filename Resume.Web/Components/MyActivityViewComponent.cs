using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Components
{
	public class MyActivityViewComponent : ViewComponent
	{
		#region Constructor

		private readonly IActivityService _activityService;

		public MyActivityViewComponent(IActivityService activityService)
		{
			_activityService = activityService;
		}

		#endregion

		#region Method

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _activityService.GetAllActivities();

			return View("MyActivity", model);
		}

		#endregion
	}
}
