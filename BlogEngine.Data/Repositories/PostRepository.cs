using BlogEngine.Data.Abstract;
using BlogEngine.Model;
using System.Linq;

namespace BlogEngine.Data.Repositories
{
    public class PostRepository : EntityBaseRepository<Post>, IPostRepository
    {
        public PostRepository(BlogEngineContext context) : base(context) { }

        public bool IncreaseViewCount(int id)
        {
            var post = GetSingle(id);

            if (post != null)
            {
                post.ViewCount++;
                Update(post);
                Commit();
                return true;
            }

            return false;
        }

        public Post GetSingle(string slug)
        {
            return Entity.Where(d => d.Slug == slug).FirstOrDefault();
        }
    }
}
