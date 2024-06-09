using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminBaseController : Controller
	{
		protected string SuccessMessage = "SuccessMessage";
		protected string ErrorMessage = "ErrorMessage";
	}
}
