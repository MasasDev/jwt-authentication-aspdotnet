using JWT_AUTHENTICATION.DTOs;
using JWT_AUTHENTICATION.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWT_AUTHENTICATION.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private static User user = new User();

    [HttpPost("register")]
    public ActionResult<User> Register(UserDTO request)
    {
        user.Name = request.Name;
        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, request.Password);

        return user;
        
    }
    [HttpPost("login")]
    public ActionResult<User> Login(UserDTO request)
    {
        if(request.Name != user.Name)
        {
            return BadRequest("The username is incorrect");
        }
        if(new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
        {
            return BadRequest("The password is incorrect");
        }

        return user;
    }

}