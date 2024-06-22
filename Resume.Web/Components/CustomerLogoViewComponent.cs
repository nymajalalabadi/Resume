using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Components
{
	public class CustomerLogoViewComponent : ViewComponent
	{
		#region Constructor

		private readonly ICustomerLogoService _customerLogoService;

		public CustomerLogoViewComponent(ICustomerLogoService customerLogoService)
		{
			_customerLogoService = customerLogoService;
		}

		#endregion

		#region Method

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _customerLogoService.GetAllCustomerLogos();

			return View("CustomerLogo", model);
		}

		#endregion
	}
}
