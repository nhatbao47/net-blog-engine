﻿using BlogEngine.Data.Abstract;
using BlogEngine.Model;
using System.Linq;

namespace BlogEngine.Data.Repositories
{
    public class PostTagRepository : EntityBaseRepository<PostTag>, IPostTagRepository
    {
        public PostTagRepository(BlogEngineContext context) : base(context) { }

        public IQueryable<Tag> GetTagsByPostId(int postId)
            => this.AllIncluding(i => i.Tag).Where(d => d.PostId == postId).Select(s => s.Tag).OrderBy(o => o.Name);

        public IQueryable<Post> GetPostsByTagId(int tagId) 
            => this.AllIncluding(i => i.Post).Where(d => d.TagId == tagId).Select(s => s.Post).OrderByDescending(o => o.CreatedDate);
    }
}
