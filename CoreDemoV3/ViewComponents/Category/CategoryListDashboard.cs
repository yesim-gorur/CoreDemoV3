using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        //view komponent olarak kategori listesi ayarlayacagım
        CategoryManager cm = new CategoryManager( new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();
            return View(values);
        
        
        
        }
    }
}
