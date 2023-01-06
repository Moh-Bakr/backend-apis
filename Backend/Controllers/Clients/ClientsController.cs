using Backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Clients;

[ApiController]
[Route("api/clients")]
public class ClientsController : ControllerBase
{
    private readonly DataContext _context;

    public ClientsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello from the client");
    }
}