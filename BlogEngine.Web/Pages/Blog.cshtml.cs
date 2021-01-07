using BlogEngine.Data.Abstract;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BlogEngine.Web.Pages
{
    public class BlogModel : PageModel
    {
        private readonly IPostRepository _repo;

        public BlogModel(IPostRepository postRepository)
        {
            _repo = postRepository;
        }

        public List<PostViewModel> Posts { get; private set; }

        public void OnGet()
        {
            Posts = _repo.AllIncluding(p => p.Category).Select(s => 
            new PostViewModel 
            {
                Id = s.Id,
                Title = s.Title,
                ShortDescription = s.ShortDescription,
                PostDate = s.CreatedDate,
                CategoryName = s.Category.Name,
                ThumbnailImage = s.ThumbnailImage
            }).ToList();
        }
    }
}
