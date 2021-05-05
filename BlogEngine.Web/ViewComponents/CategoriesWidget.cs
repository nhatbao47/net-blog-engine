using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogEngine.Web.ViewComponents
{
    public class CategoriesWidget: ViewComponent
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoriesWidget(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _repo = categoryRepository;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _repo.AllIncluding(i => i.Posts).OrderBy(o => o.Name);
            var models = _mapper.ProjectTo<CategoryViewModel>(categories).ToList();
            return View(models);
        }
    }
}
