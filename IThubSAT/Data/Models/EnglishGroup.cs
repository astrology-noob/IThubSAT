namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;

public class EnglishGroup
{   
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    //public List<Group> ParentGroups { get; set; } = null!;
    public int EnglishLevelId { get; set; }
    public EnglishLevel EnglishLevel { get; set; } = null!;
}