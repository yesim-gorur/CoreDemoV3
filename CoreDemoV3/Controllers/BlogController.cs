using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemoV3.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());//verilere erişebilmek için bunu yapmak zorundayım
        public IActionResult Index()
        {
            //index blogların listelendiği sayfa

            //  var values=bm.GetList(); ben blog listelemeyi categori adını da ekleyerek yaptıgımdan bu satır kalacak
            var values = bm.GetBlogListWithCategory();// kategoriyli olanı çağır diyorum

            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;// burda id yi taşımak istiyorum viewbag.i=id diyerek
            var values=bm.GetBlogById(id); 
            return View(values);
        
        }
        [AllowAnonymous]
        public IActionResult BlogListByWriter()//yazara göre blog listesi..sisteme otantike olan yazara göre blog listesi
        {

            var values = bm.GetListWithCategoryByWriterBm(1);
            return View(values);
        
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {


            //amacım bir dropdown ile kategorileri sıralamak bunun için kategorymanageri kullanmam lazımki verilere ulaşa bileyim

          
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   { Text=x.CategoryName,
                                                   Value=x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();






        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)//ikiside aynı isimde metod oldugundan parametre alman gerekir sen blo
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);//sen bv den gelen degerleri validate et
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());//bugunun kısa tarihini alıyorsun
                p.WriterId = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter","Blog");// ekleme yaptıktan sonra beni blog list by writera yönlendir.
            
            }
            else
            {
                foreach(var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }


            }
            return View();

        }
        public IActionResult DeleteBlog(int id)
        { //silme yapabilmen için öncelikle silinecek degeri bulman gerekiyor
            var blogvalue=bm.TGetById(id);//bu ifade ile ben ilgili blogu buldum ve degerlerini blogvalue diye bir degişkene atadım
            bm.TDelete(blogvalue);//blogvalue degerini siliyoruz komple
            return RedirectToAction("BlogListByWriter");
   
        
        
        }
        [HttpGet]// amacım sayfa yuklendiği zaman sen bana verileri getir.
        public IActionResult EditBlog(int id)//bu id almalı cünkü sebep id ye göre getirecek bana bilgileri
        {
            var blogvalue = bm.TGetById(id);// id ye göre önce bana getir degerleri
            //list ile viewbag arası komutları yazmamın amacı kategorileri dropdowna yüklemek  edit blog metodu çalıştığında bunları da yüklesin
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        
        
        }
        [HttpPost]// amacım sayfa yuklendiği zaman sen bana verileri getir.
        public IActionResult EditBlog(Blog p)//Blog cinsinden p parametresi alacak
        {
            p.WriterId = 1;
            p.BlogImage = "resim";

            bm.TUpdate(p);

            return RedirectToAction("BlogListByWriter");//sen işin bittiklten sonra bloglistby writer adresine git


        }
    }
}
