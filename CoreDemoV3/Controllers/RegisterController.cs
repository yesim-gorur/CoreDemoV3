using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Controllers
{
    public class RegisterController : Controller
    { //httpget ve http post birer attributedir get ile sayfa yüklendiğinde direk veritabanına kayıt yapmasın istiyorum
      //yeni bir yazar kaydetme işlemi yapılacak
        WriterManager wm = new WriterManager(new EfWriterRepository());//writermanagerdeki metodları çağırabilmem için bunu eklemem gerek
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] //ekleme yapılacak
        public IActionResult Index(Writer p)
        {// benim index ile ekleme yapmadan önce validasyonunu kontrol etmem gerekiyor.
            WriterValidator wv = new WriterValidator();
            ValidationResult  results=wv.Validate(p);
            if(results.IsValid)
            {
                p.WriterStatus = true;//sayfamda bu bilgiler olmadıgı için bunlara başta bu degerleri atıyorum.
                p.WriterAbout = "deneme test";
                wm.WriterAdd(p);//wm deli writer add metodunu çağırıyorum
                return RedirectToAction("Index", "Blog");//sen index sayfasına git peki o nerde blog içinde


            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                
                
                }
            }
            return View();
           
        }
    }
}
