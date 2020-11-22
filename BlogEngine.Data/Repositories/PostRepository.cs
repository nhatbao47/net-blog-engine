using BlogEngine.Data.Abstract;
using BlogEngine.Model;

namespace BlogEngine.Data.Repositories
{
    public class PostRepository : EntityBaseRepository<Post>, IPostRepository
    {
        public PostRepository(BlogEngineContext context) : base(context) { }

        public bool HasPost()
        {
            return this.Count() > 0;
        }
    }
}
