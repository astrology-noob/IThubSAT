namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Answer
{   
    [Key]
    public int Id { get; set; }
    public SurveyEntry SurveyEntry { get; set; } = null!;
    public Question Question { get; set; } = null!;
    public Workload Workload { get; set; } = null!;
    public string AnswerData { get; set; } = string.Empty;
}