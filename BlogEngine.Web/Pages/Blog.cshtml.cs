using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public int Count { get; private set; }
        public int PageSize { get; private set; } = 4;
        public int PagingCount { get; private set; } = 2;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public bool ShowPrevious => CurrentPage - PagingCount > 1;
        public bool ShowNext => CurrentPage + PagingCount < TotalPages;
        public List<PostViewModel> Posts { get; private set; }

        public void OnGet()
        {
            Count = _repo.GetAll().Count();
            var posts = _repo.AllIncluding(p => p.Category).Skip((CurrentPage - 1) * PageSize).Take(PageSize);
            Posts = _mapper.ProjectTo<PostViewModel>(posts).ToList();
        }
    }
}
