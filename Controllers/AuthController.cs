using Microsoft.AspNetCore.Mvc;
using AFKHastanesi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace AFKHastanesi.Controllers
{
    public class AuthController : Controller
    {
        AppDbContext authContext = new AppDbContext();
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
            var check = authContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == kullanici.KullaniciEmail && u.KullaniciSifre == kullanici.KullaniciSifre);

            if (check!=null)
            {
                int rol = authContext.Roller.SingleOrDefault(u => u.KullaniciID == check.KullaniciID).RolTipiID;

                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Email,kullanici.KullaniciEmail),
                    new Claim(ClaimTypes.Role,rol.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                switch (rol.ToString())
                {
                    case "1":
                        return RedirectToAction("Index", "Hasta");
                    case "2":
                        return RedirectToAction("Index", "Admin");

                    default:
                        return RedirectToAction("Index", "Hasta");
                }
            }
            else
            {
                ViewBag.HataMsg = "Hatalı Giriş Yaptınız !";
                return View("Login");
            }

        }

        public IActionResult SignUp()
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
        public IActionResult SignUp(Kullanici kullanici)
        {
            bool checkEmail = authContext.Kullanicilar.Any(u => u.KullaniciEmail == kullanici.KullaniciEmail);
           
            if (checkEmail)
            {
                ViewBag.HataMsg = "Kayıtlı Email Bulunmaktadır !!!";
                return View("SignUp");

            }
            else
            {
                authContext.Kullanicilar.Add(kullanici);
                authContext.SaveChanges();
                int id = authContext.Kullanicilar.Where(u => u.KullaniciEmail == kullanici.KullaniciEmail).Select(u => u.KullaniciID).FirstOrDefault(); ;

                Rol r = new Rol()
                {
                    RolTipiID = 1,
                    KullaniciID = id
                };
                authContext.Roller.Add(r);
                authContext.SaveChanges();
                ViewBag.SuccessMsg = "Kaydınız Oluşturulmuştur Lütfen Giriş Yapınız";
                return RedirectToAction("Login", "Auth");
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
