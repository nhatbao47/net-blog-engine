using BlogEngine.Data.Abstract;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogEngine.Web.ViewComponents
{
    public class LatestPostsWidget: ViewComponent
    {
        private readonly IPostRepository _repo;

        public LatestPostsWidget(IPostRepository postRepository)
        {
            _repo = postRepository;
        }

        public IViewComponentResult Invoke(bool compactView = true)
        {
            var recentPosts = _repo.AllIncluding(i => i.Category).OrderByDescending(o => o.UpdatedDate).Select(s => 
                new PostViewModel 
                {
                    Id = s.Id,
                    Title = s.Title,
                    ShortDescription = s.ShortDescription,
                    PostDate = s.CreatedDate,
                    CategoryName = s.Category.Name,
                    ThumbnailImage = s.ThumbnailImage,
                    ViewCount = 10,
                    CommentCount = 0
                }).Take(3).ToList();
            var model = new LatestPostsViewModel()
            {
                CompactView = compactView,
                Posts = recentPosts
            };

            return View(model);
        }
    }
}
