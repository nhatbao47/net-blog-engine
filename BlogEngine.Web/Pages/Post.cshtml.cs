using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogEngine.Web.Pages
{
    public class PostModel : PageModel
    {
        private readonly IPostRepository _repo;
        private readonly IMapper _mapper;

        public PostModel(IPostRepository postRepository, IMapper mapper)
        {
            _repo = postRepository;
            _mapper = mapper;
        }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public PostViewModel Post { get; private set; }

        public void OnGet()
        {
            var data = _repo.GetSingle(Id);
            Post = data != null ? _mapper.Map<PostViewModel>(data) : new PostViewModel();
        }
    }
}
