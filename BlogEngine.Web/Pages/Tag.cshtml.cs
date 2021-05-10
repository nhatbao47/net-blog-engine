using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.Mapping;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogEngine.Web.Pages
{
    public class TagModel : PageModel
    {
        private readonly ITagRepository _tagRepo;
        private readonly IPostTagRepository _postTagRepo;
        private readonly IMapper _mapper;

        public TagModel(ITagRepository tagRepository, IPostTagRepository postTagRepository, IMapper mapper)
        {
            _tagRepo = tagRepository;
            _postTagRepo = postTagRepository;
            _mapper = mapper;
        }

        [BindProperty(SupportsGet = true)]
        public string Slug { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; private set; } = 4;
        public int PagingCount { get; private set; } = 2;
        public string TagName { get; private set; }
        public PaginatedList<PostViewModel> Posts { get; private set; }

        public void OnGet()
        {
            var tag = _tagRepo.GetSingle(Slug);

            if (tag != null)
            {
                TagName = tag.Name;
                var posts = _postTagRepo.GetPostsByTagId(tag.Id);
                Posts = _mapper.ProjectTo<PostViewModel>(posts).ToPaginatedList(CurrentPage, PageSize);
            }
        }
    }
}
