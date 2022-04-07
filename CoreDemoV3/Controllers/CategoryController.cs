using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        //burda parantez içinde EfCategoryrepository newlememin nedeni categorymanagerda constructer tanımlanmış
        //o metodları kimin istediğini bilmek için burda efcategoryrepository diyoz buda zaten category parametresini
        //gönderiyor
        public IActionResult Index()
        {
            var values=cm.GetList();
            return View(values);
        }
    }
}
