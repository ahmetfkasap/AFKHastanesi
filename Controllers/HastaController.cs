using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AFKHastanesi.Controllers
{
    [Authorize]
    public class HastaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
