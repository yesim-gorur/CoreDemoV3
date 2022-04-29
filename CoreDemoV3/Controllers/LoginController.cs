using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemoV3.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer p)
        {
           
           Context c=new Context();
            var datavalue = c.Writers.FirstOrDefault(x=>x.WriterMail==p.WriterMail && x.WriterPassword==p.WriterPassword);
            if(datavalue!=null)
            {


                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)


                };
                var useridentity=new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");

            }
            else
            {
                return View();
            }
        }

    }
}

//Context c = new Context();
//var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);//mail ve şifre eşitlikleri sağlanıyorsa
//if (datavalue != null)
//{

//    HttpContext.Session.SetString("username", p.WriterMail);//session olarak kullanıcı adı ve writer mail tut
//    return RedirectToAction("Index", "Writer");//beni writer içerisindeki indexe yönlendir.
//}
//else
//{

//    return View();
//}