using Microsoft.AspNetCore.Mvc;
using Models;
using WebApp.Services;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ICrudService<User> _users;

    public UsersController(ICrudService<User> users)
    {
        _users = users;
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<User>> GetAll()
    {
        return Ok(_users.GetAll());
    }

    [HttpGet("{id:guid}")]
    public ActionResult<User> GetById(Guid id)
    {
        var user = _users.GetById(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public ActionResult<User> Create(User user)
    {
        user.CreatedAt = DateTime.UtcNow;
        var created = _users.Create(user);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, User user)
    {
        var existing = _users.GetById(id);
        if (existing is null)
        {
            return NotFound();
        }

        user.CreatedAt = existing.CreatedAt;
        var updated = _users.Update(id, user);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        return _users.Delete(id) ? NoContent() : NotFound();
    }
}
