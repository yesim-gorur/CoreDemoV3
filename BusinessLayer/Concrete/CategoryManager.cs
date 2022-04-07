using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //constructer oluşturacagım ben sadece EFCategoryRepositoryi kullanacagım çünkü
        //bu hem genericrepositoryi tutuyor hemde Icategorydal'ı tutuyor
        //constructar metod tanımlayarak ef categorymanagera olan bagımlılığımı azaltıyorum

        ICategoryDal _categoryDal;//bu interfacei kullanıyorum zaten bu da generic repositorye erişiyor

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
            


        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
           return _categoryDal.GetListAll();
        }
    }
}
