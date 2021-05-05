using BlogEngine.Model;
using System.Linq;

namespace BlogEngine.Data.Abstract
{
    public interface ICommentRepository: IEntityBaseRepository<Comment>
    {
        IQueryable<Comment> GetCommentsByPostId(int postId);
    }
}
