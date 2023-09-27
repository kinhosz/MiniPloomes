using Microsoft.AspNetCore.Mvc;

using miniPloomes.Models;

namespace miniPloomes.controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller {

    MiniPloomesContext _context;
    public UserController() {
        _context = new MiniPloomesContext();
    }

    [HttpGet("")]
    public async Task<ActionResult<User>> Get() {
        return new User("Joao", "joao@email.com");
    }

    [HttpPost("")]
    public ActionResult<User> Post(User user) {
        _context.InsertUser(user);
        return CreatedAtAction(nameof(Get), new { user.Id }, user);
    }
 }
