using System.ComponentModel.DataAnnotations;

namespace IThubSAT.Data.Models;

public class Chapter
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Question> Questions { get; set; } = [];
    public DisciplineType DisciplineType { get; set; }
}