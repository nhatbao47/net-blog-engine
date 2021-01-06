using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Web.ViewComponents
{
    public class LatestPostsWidget: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(1);
        }
    }
}
