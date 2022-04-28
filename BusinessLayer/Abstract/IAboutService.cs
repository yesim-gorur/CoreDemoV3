using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();// şuan için bana lazım olan şey hakkımızda sayfasına hakkımızda detaylarının getirilmesi o sebeple tek bu metodu yazdım
    }
}
