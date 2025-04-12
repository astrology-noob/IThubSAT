namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class EnglishGroup
{   
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Group Group { get; set; } = null!;
    public EnglishLevel EnglishLevel { get; set; } = null!;
}