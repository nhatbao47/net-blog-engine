using BlogEngine.Model;

namespace BlogEngine.Data.Abstract
{
    public interface IPostRepository: IEntityBaseRepository<Post>
    {
        bool IncreaseViewCount(int id);
    }
}