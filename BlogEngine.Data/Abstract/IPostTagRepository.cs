using BlogEngine.Model;
using System.Linq;

namespace BlogEngine.Data.Abstract
{
    public interface IPostTagRepository: IEntityBaseRepository<PostTag>
    {
        IQueryable<Tag> GetTagsByPostId(int postId);
        IQueryable<Post> GetPostsByTagId(int tagId);
    }
}
