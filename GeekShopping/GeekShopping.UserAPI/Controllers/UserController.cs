using GeekShopping.UserAPI.Model;
using GeekShopping.UserAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.UserAPI.Controllers;

[ApiController]
[Route("v1")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]   
    [Authorize]
    public async Task<ActionResult<IEnumerable<User>>> FindAll()
    {
        var users = await _repository.FindAll();

        return Ok(users);
    }

    [HttpGet("{id}")]    
    [Authorize(Roles = "admin")]
    
    public async Task<ActionResult<User>> FindById(long id)
    {
        var user = await _repository.FindById(id);

        if (user == null) return NotFound();

        return Ok(user);
    }
}
