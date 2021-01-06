using BlogEngine.Data;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogEngine.Web.ViewComponents
{
    public class CategoriesWidget: ViewComponent
    {
        private readonly ICategoryRepository repository;

        public CategoriesWidget(ICategoryRepository categoryRepository)
        {
            repository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = repository.AllIncluding(i => i.Posts).Select(s => 
                new CategoryViewModel 
                {
                    Id = s.Id,
                    Name = s.Name,
                    PostCount = s.Posts.Count
                }).ToList();
            return View(categories);
        }
    }
}
