using Backend.Data;
using Backend.Services.Clients;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Clients;

[ApiController]
[Route("api/client")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Clients.Clients>>> GetClients()
    {
        var data = await _clientService.GetClients();
        if (data == null || !data.Any())
        {
            return NotFound("No clients found");
        }
        return Ok(data);
    }
    
    
    
    [HttpGet("{code}")]
    public async Task<ActionResult<Models.Clients.Clients>> GetSample(string code)
    {
        var data = await _clientService.GetClientByCode(code);
        if (data == null)
        {
            return NotFound($"Client {code} not found");
        }

        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult<Models.Clients.Clients>> CreateClient(Models.Clients.Clients client)
    {
        var result = await _clientService.CreateClient(client);
        if (result == null)
        {
            return BadRequest("Clients with this code already exists");
        }
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Models.Clients.Clients>> UpdateClient(Models.Clients.Clients client, int id)
    {
        var data = await _clientService.UpdateClient(client, id);
        if (data == null)
        {
            return NotFound("no Client with this id");
        }

        return Ok("Client updated");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Models.Clients.Clients>> DeleteClient(int id)
    {
        var result = await _clientService.DeleteClient(id);
        if (result is null)
        {
            return NotFound("Client not found");
        }

        return Ok("Client Deleted");
    }
}