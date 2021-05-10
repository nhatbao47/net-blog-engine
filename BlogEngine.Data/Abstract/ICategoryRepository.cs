using BlogEngine.Model;

namespace BlogEngine.Data.Abstract
{
    public interface ICategoryRepository: IEntityBaseRepository<Category>
    {
        Category GetSingle(string slug);
    }
}
