using CoreDemoV3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoV3.ViewComponents
{
    public class CommentList : ViewComponent
    {

        public IViewComponentResult Invoke()//metodumun adı invoke olacak
        {
            var commentvalues = new List<UserComment>
            {



                new UserComment

                { 
                    ID = 1,
                    UserName ="ayse"

                }
            };

            return View();



        }





    }
}
