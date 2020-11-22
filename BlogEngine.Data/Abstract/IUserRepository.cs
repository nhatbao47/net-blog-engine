using BlogEngine.Model;

namespace BlogEngine.Data.Abstract
{
    public interface IUserRepository: IEntityBaseRepository<User>
    {
        bool IsEmailUnique(string email);
        bool IsUsernameUnique(string username);
    }
}
