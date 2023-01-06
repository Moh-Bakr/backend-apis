using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Sample;

public class Sample
{
    [Key] public int Id { get; set; }
    [Required] public string receiving_party { get; set; }
    [Required] public string client_name { get; set; }
    public string? date { get; set; }
    public string? description { get; set; }
    [Required] public string qutaity { get; set; }
    public string? extra { get; set; }
    [Required] public string price { get; set; }
    [Required] public string status { get; set; }
}