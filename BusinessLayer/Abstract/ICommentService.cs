using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment comment);// yorum ekle
     //   void CommentDelete(Comment comment);
     //  void CommentUpdate(Comment comment);
     //   Comment GetById(int id);
        List<Comment> GetList(int id);// yorum listele
    }
}
