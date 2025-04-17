namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Survey
{   
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IntroductionText { get; set; } = string.Empty;
    public string ConclusionText { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
    public string ModifiedAt { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
    public User CreatedBy { get; set; } = null!;
    public bool IsOpen { get; set; }
    public List<Question> Questions { get; set; } = [];
    public List<Workload> Workloads { get; } = [];
    public List<UserRespondedToSurvey> UsersRespondedToSurvey { get; } = [];
}