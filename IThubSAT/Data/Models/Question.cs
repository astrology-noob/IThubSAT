namespace IThubSAT.Data.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
public class Question
{   
    [Key]
    public int Id { get; set; } 
    public string Text { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; } = null!;
    public QuestionType QuestionType { get; set; }
    public string QuestionTypeInfo { get; set; } = string.Empty; // а, это поле в котором конкретно инфа содержится, соответствующая маске
    public DisciplineType DisciplineType { get; set; }
}

public enum QuestionType
{
    [Description("mask")]
    Scale = 1,
    SingleChoice = 2,
    MultipleChoice = 3,
    ShortText = 4,
    LongText = 5
}