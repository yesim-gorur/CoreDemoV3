using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            //index blogların listelendiği sayfa
            return View();
        }
    }
}
