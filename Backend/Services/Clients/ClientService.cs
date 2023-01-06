using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Clients;

public class ClientService : IClientService
{
    private readonly DataContext _context;

    public ClientService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Models.Clients.Clients>> GetClients()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Models.Clients.Clients> CreateClient(Models.Clients.Clients client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Models.Clients.Clients>? UpdateClient(Models.Clients.Clients client, int id)
    {
        var clientToUpdate = await _context.Clients.FindAsync(id);
        // var clientToUpdate = Clients.Find(x => x.Id == id);
        if (clientToUpdate == null)
        {
            return null;
        }

        clientToUpdate.Arabic_Name = client.Arabic_Name;
        clientToUpdate.English_Name = client.English_Name;
        clientToUpdate.Email = client.Email;
        clientToUpdate.Mobile = client.Mobile;
        clientToUpdate.Phone = client.Phone;
        clientToUpdate.Address = client.Address;
        clientToUpdate.code = client.code;

        await _context.SaveChangesAsync();
        return clientToUpdate;
    }


    public async Task<Models.Clients.Clients>? DeleteClient(int id)
    {
        var clientToDelete = await _context.Clients.FindAsync(id);
        if (clientToDelete == null)
        {
            return null;
        }

        _context.Clients.Remove(clientToDelete);
        await _context.SaveChangesAsync();
        return clientToDelete;
    }
}