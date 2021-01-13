using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BlogEngine.Web.Pages
{
    public class PostModel : PageModel
    {
        private readonly IPostRepository _repo;
        private readonly ICommentRepository _commentRepo;
        private readonly IMapper _mapper;

        public PostModel(IPostRepository postRepository, ICommentRepository commentRepository, IMapper mapper)
        {
            _repo = postRepository;
            _commentRepo = commentRepository;
            _mapper = mapper;
        }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public PostViewModel Post { get; private set; }
        public List<CommentViewModel> Comments { get; private set; }

        public void OnGet()
        {
            _repo.IncreaseViewCount(Id);
            var data = _repo.GetSingle(Id);

            if (data != null)
            {
                var postComments = _commentRepo.FindBy(d => d.PostId == Id).OrderBy(o => o.CommentDate);
                Comments = _mapper.ProjectTo<CommentViewModel>(postComments).ToList();
                Post = _mapper.Map<PostViewModel>(data);
                Post.CommentCount = Comments.Count;
            } 
            else
            {
                Post = new PostViewModel();
                Comments = new List<CommentViewModel>();
            }
        }
    }
}
