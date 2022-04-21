using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.ViewComponents.Blog
{
    public class WriterLastBlog:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListByWriter(1);//deneme amaçlı 1 yazdım
            return View(values);
        
        
        
        }
    }
}
//ben bu sayfada yazar id sine göre blog getircem blogmanager deki metodu kullanacagım için onu newledim