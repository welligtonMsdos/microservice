using GeekShopping.UserAPI.Data.ValueObjects;
using GeekShopping.UserAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.UserAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]   
    [Authorize]
    public async Task<ActionResult<IEnumerable<UserResult>>> FindAll()
    {
        var users = await _repository.FindAll();

        return Ok(users);
    }

    [HttpGet("{UserName}/{Password}")]
    public async Task<ActionResult<UserResult>> FindByNameAndPassword(string UserName, string Password)
    {
        UserVO vo = new UserVO();
        vo.UserName = UserName;
        vo.Password = Password;

        var user = await _repository.FindByNameAndPassword(vo);

        if (user == null) return NotFound();

        return Ok(user);
    }

    [HttpGet("{id}")]  
    public async Task<ActionResult<UserResult>> FindById(long id)
    {
        var user = await _repository.FindById(id);

        if (user == null) return NotFound();

        return Ok(user);
    }

    [HttpPost]
    [HttpPost]
    public async Task<ActionResult<UserViewModel>> Create([FromBody] UserViewModel vo)
    {
        if (vo == null) return BadRequest();

        var user = await _repository.Create(vo);

        return Ok(user);
    }

    [HttpPut]
    public async Task<ActionResult<UserViewModelWithId>> Update([FromBody] UserViewModelWithId vo)
    {
        if (vo == null) return BadRequest();

        var user = await _repository.Update(vo);

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var status = await _repository.Delete(id);

        if (!status) return BadRequest();

        return Ok(status);
    }
}
