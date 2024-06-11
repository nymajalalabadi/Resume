using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.Account;
using System.Security.Claims;

namespace Resume.Web.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region Constructor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Actions

        #region Login

        [HttpGet("login")]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var result = await _userService.Login(login);

            switch (result)
            {
                case LoginResult.Success:

                    var user = await _userService.GetUserByEmail(login.Email);

                    #region Login

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user!.Id.ToString()),
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.MobilePhone, user.Mobile)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(principal, properties);

                    TempData[SuccessMessage] = "خوش آمدید!";

                    #endregion

                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                case LoginResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است لطفا مجدد تلاش کنید.";
                    return View(login);

                case LoginResult.UserNotFound:

                    TempData[ErrorMessage] = "کاربری یافت نشد.";
                    return View(login);
            }

            return View(login);
        }

        #endregion

        #region Logout

        [HttpGet("logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion


        #endregion
    }
}
