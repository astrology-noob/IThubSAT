using System.ComponentModel.DataAnnotations;
namespace IThubSAT.Data.Models;

public class SurveyEntry
{   
    [Key]
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; } = null!;
    public string SubmittedAt { get; set; } = string.Empty;
    public List<Answer> Answers { get; set; } = new();
}