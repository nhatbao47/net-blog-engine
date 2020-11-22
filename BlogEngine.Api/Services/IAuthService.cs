using BlogEngine.Api.ViewModels;

namespace BlogEngine.Api.Services
{
    public interface IAuthService
    {
        AuthData GetAuthData(int id);
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}
