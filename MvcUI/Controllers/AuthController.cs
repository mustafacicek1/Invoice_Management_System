using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MvcUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = _userService.VerifyUser(loginDTO);
            if (result.Success)
            {
                var claims = new List<Claim>() {
                new Claim (ClaimTypes.Role,result.UserRole),
                new Claim (ClaimTypes.NameIdentifier,result.UserId.ToString())};
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                if (result.UserRole == "Admin")
                {
                    return RedirectToAction("GetMessages", "Message");
                }
                return RedirectToAction("GetMyInvoices", "Invoice");
            }
            ViewBag.message = "T.C. No or password incorrect";
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
