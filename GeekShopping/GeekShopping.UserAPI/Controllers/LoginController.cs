using GeekShopping.UserAPI.Data.ValueObjects;
using GeekShopping.UserAPI.Repository;
using GeekShopping.UserAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.UserAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public LoginController(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserVO model)
    {
        var user = await _repository.FindByNameAndPassword(model);

        if (user == null) return NotFound(new {message = "Invalid username or password" });

        var token = _tokenService.GenerateToken(user);

        user.Password = "";

        return new
        {
            user = user,
            token = token
        };
    }
}
