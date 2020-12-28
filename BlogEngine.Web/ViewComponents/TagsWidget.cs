using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogEngine.Web.ViewComponents
{
    public class TagsWidget: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var tags = new List<string>() { "Business", "Technology", "Fashion", "Sports", "Economy" };
            return View(tags);
        }
    }
}
