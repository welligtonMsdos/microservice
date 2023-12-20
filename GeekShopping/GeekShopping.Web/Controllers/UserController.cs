using GeekShopping.Web.Data.ValueObjects;
using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    [Authorize]
    public async Task<IActionResult> UserIndex()
    {
        var users = await _userService.FindAll();

        return View(users);
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UserCreate()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UserCreate(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _userService.Create(model);

            if (response != null) return RedirectToAction(nameof(UserIndex));
        }

        return View(model);
    }

    [Authorize(Roles = "admin,client")]
    public async Task<IActionResult> UserUpdate(int id)
    {
        var model = await _userService.FindById(id);

        if (model != null) return View(model);

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> UserUpdate(UserViewModelWithId model)
    {
        if (ModelState.IsValid)
        {
            var response = await _userService.Update(model);

            if (response != null) return RedirectToAction(nameof(UserIndex));
        }

        return View(model);
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UserDelete(int id)
    {
        var model = await _userService.FindById(id);

        if (model != null) return View(model);

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> UserDelete(User model)
    {
        var response = await _userService.Delete(model.Id);

        if (response) return RedirectToAction(nameof(UserIndex));

        return View(model);
    }
}
