namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class Discipline
{   
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DisciplineTypeId { get; set; }
    public DisciplineType DisciplineType { get; set; }
    public bool IsOptional { get; set; }
}