using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Controllers
{
    public class ContactUsController : SiteBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
