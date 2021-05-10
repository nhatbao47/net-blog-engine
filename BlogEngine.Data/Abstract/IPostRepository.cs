using BlogEngine.Model;
using System.Linq;

namespace BlogEngine.Data.Abstract
{
    public interface IPostRepository: IEntityBaseRepository<Post>
    {
        bool IncreaseViewCount(int id);
        Post GetSingle(string slug);
        IQueryable<Post> GetPostsByCategoryId(int categoryId);
    }
}