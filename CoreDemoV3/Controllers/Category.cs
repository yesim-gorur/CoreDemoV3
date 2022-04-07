using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
