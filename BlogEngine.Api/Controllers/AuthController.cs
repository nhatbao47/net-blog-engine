using BlogEngine.Api.Services;
using BlogEngine.Api.ViewModels;
using BlogEngine.Data.Abstract;
using BlogEngine.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        IAuthService authService;
        IUserRepository userRepository;

        public AuthController(IAuthService authService, IUserRepository userRepository)
        {
            this.authService = authService;
            this.userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult<AuthData> Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = userRepository.GetSingle(u => u.Username == model.Username);

            if (user == null) return BadRequest("Username or password invalid");

            var isValid = authService.VerifyPassword(model.Password, user.Password);

            if (!isValid) return BadRequest("Username or password invalid");
            return authService.GetAuthData(user.Id);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult<AuthData> Register([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!userRepository.IsUsernameUnique(model.Username))
            {
                return BadRequest("Username already exists");
            }

            if (!userRepository.IsEmailUnique(model.Email))
            {
                return BadRequest("Email already exists");
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = authService.HashPassword(model.Password)
            };

            userRepository.Add(user);
            userRepository.Commit();
            return authService.GetAuthData(user.Id);
        }
    }
}
