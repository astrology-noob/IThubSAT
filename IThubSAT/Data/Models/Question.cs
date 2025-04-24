namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class Question
{   
    [Key]
    public int Id { get; set; } 
    public string Text { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; } = null!;
    public int QuestionTypeId { get; set; }
    public QuestionType QuestionType { get; set; } = null!;
    public int DisciplineTypeId { get; set; }
    public DisciplineType DisciplineType { get; set; } = null!;
}