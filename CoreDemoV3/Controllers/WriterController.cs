using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Controllers
{
    
    public class WriterController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {

            return View();
        
        }
     
        public IActionResult WriterName()
        {
            return View();
        
        
        }
        //writer ile alakalı bir sayfa oluşturacagaım bunun için
        [AllowAnonymous] // şuan test sayfam açılsın diye allowanoymous yaptım
        public IActionResult Test()
        {

            return View();


        }
    }
}
