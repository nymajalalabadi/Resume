using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ActivityController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
