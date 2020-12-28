using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogEngine.Web.ViewComponents
{
    public class CategoriesWidget: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var list = new List<CategoryModel>();
            for (int i = 1; i <= 5; i++)
            {
                var item = new CategoryModel
                {
                    Id = i,
                    Name = "Category " + i,
                    PostCount = i
                };
                list.Add(item);
            }
            return View(list);
        }
    }
}
