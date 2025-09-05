using System.ComponentModel.DataAnnotations;
namespace IThubSAT.Data.Models;

public class SportClub
{   
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}