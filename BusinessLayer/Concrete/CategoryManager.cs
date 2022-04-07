using BusinessLayer.Abstract;
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
        EfCategoryRepository efCategoryRepository;
        public CategoryManager()
        {
            efCategoryRepository=new EfCategoryRepository();
        }
        public void CategoryAdd(Category category)
        {
            efCategoryRepository.Insert(category);


        }

        public void CategoryDelete(Category category)
        {
            efCategoryRepository.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            efCategoryRepository.Update(category);
        }

        public Category GetById(int id)
        {
            return efCategoryRepository.GetById(id);
        }

        public List<Category> ListAllCategory()
        {
           return efCategoryRepository.GetListAll();
        }
    }
}
