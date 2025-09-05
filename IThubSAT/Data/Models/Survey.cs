using System.ComponentModel.DataAnnotations;
namespace IThubSAT.Data.Models;

public class Survey
{   
    [Key]
    public int Id { get; set; }

    [Required]  
    [StringLength(50, ErrorMessage = "Максимум 50 символов.")]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string IntroductionText { get; set; } = string.Empty;
    public string ConclusionText { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
    public string ModifiedAt { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;
    public bool IsOpen { get; set; }
    public List<Chapter> Chapters { get; set; } = [];
    public List<Workload> Workloads { get; } = [];
    public List<UserRespondedToSurvey> UsersRespondedToSurvey { get; } = [];
}