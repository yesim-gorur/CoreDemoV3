using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Views.Shared.Components.Comments
{
    public class CommentListByBlog : ViewComponent//view component oldugundan burdan miras alacak
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
           
            var values = cm.GetList(id);
            return View(values);



        }
    }
}
