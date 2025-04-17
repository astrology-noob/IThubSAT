namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class SectionType
{   
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
}