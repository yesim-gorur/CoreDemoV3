using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }//konstructer

        //public void BlogAdd(Blog blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public void BlogDelete(Blog blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public void BlogUpdate(Blog blog)
        //{
        //    throw new NotImplementedException();
        //}
        // parametreli bir şekilde
        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetList()// blogları biz birdan alıyoruz
        {
            return _blogDal.GetListAll();
        }
        public List<Blog> GetLast3Blog()// blogları biz birdan alıyoruz son 3 blogu cagır
        {
            return _blogDal.GetListAll().Take(3).ToList();//sadece3 tanesini getir.
        }
        public List<Blog> GetBlogById(int id)
        { 
         return _blogDal.GetListAll(x=>x.BlogId== id);
        
        
        }
        //yukarıdaki iki metod  miras almadan oluşturulan metod
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterId == id);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);//ekleme metodu tabiki ekleme işlemi yaparken parametreli bir şekilde yapıyoruz.
        }

        public void TDelete(Blog t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Blog t)
        {
            throw new NotImplementedException();
        }
        public List<Blog> Test(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }
    }
}
