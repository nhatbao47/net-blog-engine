using AutoMapper;
using BlogEngine.Data.Abstract;
using BlogEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogEngine.Web.ViewComponents
{
    public class TagsWidget: ViewComponent
    {
        private readonly ITagRepository _repo;
        private readonly IMapper _mapper;

        public TagsWidget(ITagRepository tagRepository, IMapper mapper)
        {
            _repo = tagRepository;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var tags = _repo.GetAll().OrderBy(o => o.Name);
            var models = _mapper.ProjectTo<TagViewModel>(tags).ToList();
            return View(models);
        }
    }
}
