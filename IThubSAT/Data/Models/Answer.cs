namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class Answer
{   
    [Key]
    public int Id { get; set; }
    public int SurveyEntryId { get; set; }
    public SurveyEntry SurveyEntry { get; set; } = null!;
    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;
    public int WorkloadId { get; set; }
    public Workload Workload { get; set; } = null!;
    public string AnswerData { get; set; } = string.Empty;
}