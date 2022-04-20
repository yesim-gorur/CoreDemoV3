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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        //manager kısmında konstructer oluşturmak zorundayım
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)// yorum ekleme
        {
            _commentDal.Insert(comment);
        }

        public List<Comment> GetList(int id)//yorumları listeleme ama id ye göre listeleme yapıyoruz
        {
            return _commentDal.GetListAll(x=>x.BlogId==id);
            //normalde  return _commentDal.GetListAll();
            //yukarıdakinde şart yazıyorsun
            // ben blogid ye göre listeliyorum
        }

        
    }
}
