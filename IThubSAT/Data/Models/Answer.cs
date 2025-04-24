namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class Answer
{   
    [Key]
    public int Id { get; set; }
    public SurveyEntry SurveyEntry { get; set; } = null!;
    public Question Question { get; set; } = null!;
    // насколько это нужно? конкретную workload можно найти в процессе, просто чтобы не хранить конфликтующие данные в surveyentry
    // может просто хранить здесь дисциплину? А что делать с дополнительными полями типа "преподаватель английского" или "уровень английского"?
    public Workload Workload { get; set; } = null!;
    public string AnswerData { get; set; } = string.Empty;
}