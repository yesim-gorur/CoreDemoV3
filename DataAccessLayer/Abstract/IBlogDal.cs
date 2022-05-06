using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();//sadece ilgili entitye ait bir metoda ihtiyac duyuduğunda böyle bir yapı kuruyoruz
                                         //yani bu spesifik birşey
        List<Blog> GetListWithCategoryByWriter(int id);

        
    }
}
