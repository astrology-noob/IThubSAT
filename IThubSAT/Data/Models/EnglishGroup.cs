namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;

// связать с группами обычными? или оставить связь через workload?
public class EnglishGroup
{   
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int EnglishLevelId { get; set; }
    public EnglishLevel EnglishLevel { get; set; } = null!;
}