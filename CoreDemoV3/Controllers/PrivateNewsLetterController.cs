using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Controllers
{
    public class PrivateNewsLetterController : Controller
    {
        PrivateNewsLetterManager pnm = new PrivateNewsLetterManager(new EfPrivateNewsLetterRepository());
        [HttpGet]
        public PartialViewResult SubcribePrivateMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubcribePrivateMail(PrivateNewsLetter p)
        {
            p.MailStatus = true;
            pnm.AddPrivateNewsLetter(p);
            return PartialView();
        }
    }
}
