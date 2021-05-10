using BlogEngine.Data.Abstract;
using BlogEngine.Model;
using System.Linq;

namespace BlogEngine.Data.Repositories
{
    public class TagRepository : EntityBaseRepository<Tag>, ITagRepository
    {
        public TagRepository(BlogEngineContext context) : base(context) { }

        public Tag GetSingle(string slug) => this.Entity.FirstOrDefault(d => d.Slug == slug.Trim());
    }
}
