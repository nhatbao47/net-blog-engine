using BlogEngine.Data.Abstract;
using BlogEngine.Model;

namespace BlogEngine.Data.Repositories
{
    public class CategoryRepository : EntityBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogEngineContext context) : base(context) { }

        public bool HasCategory()
        {
            return this.Count() > 0;
        }
    }
}
