using BlogEngine.Data.Abstract;
using BlogEngine.Model;
using System.Linq;

namespace BlogEngine.Data.Repositories
{
    public class CategoryRepository : EntityBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogEngineContext context) : base(context) { }

        public Category GetSingle(string slug) => this.Entity.FirstOrDefault(d => d.Slug == slug.Trim());
    }
}
