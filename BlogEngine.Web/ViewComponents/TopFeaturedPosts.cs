using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogEngine.Web.ViewComponents
{
    public class TopFeaturedPosts: ViewComponent
    {
        private readonly IPostRepository _repo;
        private readonly IMapper _mapper;

        public TopFeaturedPosts(IPostRepository postRepository, IMapper mapper)
        {
            _repo = postRepository;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var posts = _repo.GetTopFeaturedPosts();
            var models = _mapper.ProjectTo<PostViewModel>(posts).ToList();
            return View(models);
        }
    }
}
