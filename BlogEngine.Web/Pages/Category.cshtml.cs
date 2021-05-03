using System.Linq;
using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.Mapping;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogEngine.Web.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IPostRepository _postRepo;
        private readonly IMapper _mapper;

        public CategoryModel(ICategoryRepository categoryRepository, IPostRepository postRepository, IMapper mapper)
        {
            _categoryRepo = categoryRepository;
            _postRepo = postRepository;
            _mapper = mapper;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; private set; } = 4;
        public int PagingCount { get; private set; } = 2;
        public PaginatedList<PostViewModel> Posts { get; private set; }
        public string CategoryName { get; private set; }

        public void OnGet()
        {
            var category = _categoryRepo.GetSingle(Id);
            CategoryName = category?.Name;

            var posts = _postRepo.AllIncluding(p => p.Category).Where(d => d.CategoryId == Id).OrderByDescending(o => o.CreatedDate);
            Posts = _mapper.ProjectTo<PostViewModel>(posts).ToPaginatedList(CurrentPage, PageSize);
        }
    }
}
