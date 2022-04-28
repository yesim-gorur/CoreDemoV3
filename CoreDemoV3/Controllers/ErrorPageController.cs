using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1( int code)
        {
            // burda sayfa adımı error 1 dedim program.cs dede buna atıf yaptım
            return View();
        }
    }
}
