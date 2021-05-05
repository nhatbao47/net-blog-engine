using BlogEngine.Data.Abstract;
using BlogEngine.Model;
using System.Linq;

namespace BlogEngine.Data.Repositories
{
    public class CommentRepository : EntityBaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogEngineContext context) : base(context) { }
        public IQueryable<Comment> GetCommentsByPostId (int postId) => this.FindBy(d => d.PostId == postId).OrderByDescending(o => o.CommentDate);
    }
}
