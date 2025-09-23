using System.ComponentModel.DataAnnotations;
namespace IThubSAT.Data.Models;

public class Chapter
{
    [Key]
    public int Id { get; set; }
    public List<Question> Questions { get; set; } = [];
    public DisciplineType DisciplineType { get; set; }
}