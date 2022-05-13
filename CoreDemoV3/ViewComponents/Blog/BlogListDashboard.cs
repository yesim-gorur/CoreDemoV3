using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            //burda blogları listeleyecegim bu controlerdaki blog controler gibi birşey o sebeple blog manageri çağıracagım
            var values = bm.GetBlogListWithCategory();
        
            return View(values);
        
        }
    }
}
