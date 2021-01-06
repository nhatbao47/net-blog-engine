using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Web.ViewComponents
{
    public class SearchBarWidget: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(1);
        }
    }
}
