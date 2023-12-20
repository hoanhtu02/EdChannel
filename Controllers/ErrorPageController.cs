using Microsoft.AspNetCore.Mvc;

namespace EdChannel.Controllers
{
        [Route("ErrorPage/{code}")]
    public class ErrorPageController : Controller
    {
        public IActionResult Index(int? code)
        {
            switch (code)
            {   
                case 404:
                    ViewData["ErrorCode"] = "404";
                    ViewData["ErrorPage"] = "Page Not Found";
                    ViewData["ErrorContent"] = "The page you requested was not found.";
                    break;
                case 500:
                    ViewData["ErrorCode"] = "500";
                    ViewData["ErrorPage"] = "Something went wrong";
                    ViewData["ErrorContent"] = "Please contact to administrator of this page.";
                    break;
                default:
                    ViewData["ErrorCode"] = code.ToString();
                    ViewData["ErrorPage"] = "Something went wrong";
                    ViewData["ErrorContent"] = "Please contact to administrator of this page.";
                    break;
            }
            return View();
        }
    }
}
