namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Discipline
{   
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DisciplineType DisciplineType { get; set; } = null!;
    public bool IsOptional { get; set; }
}