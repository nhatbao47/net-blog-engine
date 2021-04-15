using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Model;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
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
        public string Slug { get; set; }
        public PostViewModel Post { get; private set; }
        public List<CommentViewModel> Comments { get; private set; }

        [BindProperty]
        public CommentViewModel NewComment { get; set; }

        public IActionResult OnGet()
        {
            LoadPostAndComments(Slug);

            if (Post == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var submitComment = new Comment()
                {
                    PostId = NewComment.PostId,
                    Name = NewComment.Name,
                    EmailAddress = NewComment.EmailAddress,
                    Content = NewComment.Content,
                    CommentDate = DateTime.Now
                };
                _commentRepo.Add(submitComment);
                _commentRepo.Commit();

                ModelState.Clear();
                NewComment = new CommentViewModel();
            }

            LoadPostAndComments(Slug);
            return Page();
        }

        private void LoadPostAndComments(string slug)
        {
            var data = _repo.GetSingle(slug);

            if (data != null)
            {
                var postComments = _commentRepo.FindBy(d => d.PostId == data.Id).OrderByDescending(o => o.CommentDate);
                Comments = _mapper.ProjectTo<CommentViewModel>(postComments).ToList();
                Post = _mapper.Map<PostViewModel>(data);
                Post.CommentCount = Comments.Count;
            }
        }
    }
}
