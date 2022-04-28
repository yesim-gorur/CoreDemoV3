using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager( new EfAboutRepository());
        public IActionResult Index()//index sayfası oluşturmalıyım ve buraya verileri listeletyecegim
        {
            var values = abm.GetList();
            return View(values);
        }
        public PartialViewResult SocialMediaAbout()
        {
            
            return PartialView();
        
        }
    }
}
