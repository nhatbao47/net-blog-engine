using BlogEngine.Model;

namespace BlogEngine.Data.Abstract
{
    public interface IPostRepository: IEntityBaseRepository<Post>
    {
        bool IncreaseViewCount(int id);
        Post GetSingle(string slug);
    }
}