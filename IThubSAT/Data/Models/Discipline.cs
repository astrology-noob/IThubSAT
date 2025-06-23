namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class Discipline
{   
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DisciplineType DisciplineType { get; set; }
    public bool IsOptional { get; set; }
}

public enum DisciplineType
{
    General = 1,
    English = 2,
    Sport = 3
}