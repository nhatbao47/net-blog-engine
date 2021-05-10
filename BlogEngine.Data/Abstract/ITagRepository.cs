using BlogEngine.Model;

namespace BlogEngine.Data.Abstract
{
    public interface ITagRepository: IEntityBaseRepository<Tag>
    {
        Tag GetSingle(string slug);
    }
}
