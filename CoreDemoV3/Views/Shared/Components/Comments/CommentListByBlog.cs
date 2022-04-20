using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.Views.Shared.Components.Comments
{
    public class CommentListByBlog : ViewComponent//view component oldugundan burdan miras alacak
    {
        public IViewComponentResult Invoke(int id)
        {
            CommentManager cm = new CommentManager(new EfCommentRepository());
            var values = cm.GetList(id);
            return View(values);



        }
    }
}
