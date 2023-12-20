using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdChannel.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin,Member")]
    public class DashboardController : Controller
    {
        [HttpGet("/dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
