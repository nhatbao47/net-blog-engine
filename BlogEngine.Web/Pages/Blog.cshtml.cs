using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.Mapping;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogEngine.Web.Pages
{
    public class BlogModel : PageModel
    {
        private readonly IPostRepository _repo;
        private readonly IMapper _mapper;

        public BlogModel(IPostRepository postRepository, IMapper mapper)
        {
            _repo = postRepository;
            _mapper = mapper;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; private set; } = 4;
        public int PagingCount { get; private set; } = 2;
        public PaginatedList<PostViewModel> Data { get; private set; }

        public void OnGet()
        {
            var posts = _repo.AllIncluding(p => p.Category);
            Data = _mapper.ProjectTo<PostViewModel>(posts).ToPaginatedList(CurrentPage, PageSize);
        }
    }
}
