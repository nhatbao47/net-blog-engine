using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogEngine.Web.ViewComponents
{
    public class LatestPostsWidget: ViewComponent
    {
        private readonly IPostRepository _repo;
        private readonly IMapper _mapper;

        public LatestPostsWidget(IPostRepository postRepository, IMapper mapper)
        {
            _repo = postRepository;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(ViewMode view)
        {
            var recentPosts = _repo.AllIncluding(i => i.Category).OrderByDescending(o => o.UpdatedDate).Take(3);
            var model = new LatestPostsViewModel()
            {
                View = view,
                Posts = _mapper.ProjectTo<PostViewModel>(recentPosts).ToList()
            };

            return View(model);
        }
    }
}
