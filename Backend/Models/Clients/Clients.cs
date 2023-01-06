using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Clients;

public class Clients
{
    [Key] public int Id { get; set; }
    [Required] public string English_Name { get; set; }
    [Required] public string Arabic_Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    [Required] public string Mobile { get; set; }
    public string? Address { get; set; }
    [Required] public string code { get; set; }
}