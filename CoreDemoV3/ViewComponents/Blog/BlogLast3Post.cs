using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        //yeni bir vievcomponent oluşturuyoruz
        //bunu controller gibi düşünüyoruz.
        BlogManager bm = new BlogManager( new EfBlogRepository());// controller gibi düşündüğüm için blokmanageri çağırmak zorundayım
        public IViewComponentResult Invoke()
        {

            var values = bm.GetLast3Blog();//managerda tanımladıgım metodları çağırıyorum
            return View(values);
        
        
        
        }


    }
}
