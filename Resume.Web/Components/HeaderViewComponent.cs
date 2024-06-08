using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Components
{
	public class HeaderViewComponent : ViewComponent
	{
		#region Fields



		#endregion

		#region Constructor



		#endregion

		#region Method

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Header");
		}

		#endregion

	}
}
