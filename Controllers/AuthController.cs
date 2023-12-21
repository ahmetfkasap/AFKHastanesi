using Microsoft.AspNetCore.Mvc;
using AFKHastanesi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace AFKHastanesi.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;

            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                string rol = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

                switch ("1")
                {
                    case "1":
                        return RedirectToAction("Index", "Hasta");

                    default:
                        return RedirectToAction("Index", "Hasta");
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Kullanici kullanici)
        {

            if (kullanici.KullaniciEmail=="kasap@gmail.com"&&kullanici.KullaniciSifre=="123456")
            {
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Email,kullanici.KullaniciEmail),
                    new Claim(ClaimTypes.Role,"1")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                switch ("1")
                {
                    case "1":
                        return RedirectToAction("Index", "Hasta");

                    default:
                        return RedirectToAction("Index", "Hasta");
                }
            }
            else
            {
                return View("Login");
            }

        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Kullanici kullanici)
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }
    }
}
