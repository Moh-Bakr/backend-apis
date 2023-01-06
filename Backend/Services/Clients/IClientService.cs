namespace Backend.Services.Clients;

public interface IClientService
{
    Task<List<Models.Clients.Clients>> GetClients();
    Task<Models.Clients.Clients> CreateClient(Models.Clients.Clients client);
    
    Task<Models.Clients.Clients>? UpdateClient(Models.Clients.Clients client, int id);
    Task<Models.Clients.Clients>? DeleteClient(int id);
    
}