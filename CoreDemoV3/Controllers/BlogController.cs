using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            //index blogların listelendiği sayfa

            //  var values=bm.GetList(); ben blog listelemeyi categori adını da ekleyerek yaptıgımdan bu satır kalacak
            var values = bm.GetBlogListWithCategory();// kategoriyli olanı çağır diyorum

            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        { 
        
            var values=bm.GetBlogById(id); 
            return View(values);
        
        }
    }
}
