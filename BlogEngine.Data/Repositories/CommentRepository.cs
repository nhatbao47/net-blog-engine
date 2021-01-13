using BlogEngine.Data.Abstract;
using BlogEngine.Model;

namespace BlogEngine.Data.Repositories
{
    public class CommentRepository : EntityBaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogEngineContext context) : base(context) { }
    }
}
