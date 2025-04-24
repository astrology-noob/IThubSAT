namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class Workload
{   
    [Key]
    public int Id { get; set; } 
    public int SurveyId { get; set; }
    public Survey Survey { get; set; } = null!;
    public int? GroupId { get; set; }
    public Group? Group { get; set; } = null!;
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; } = null!;
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public int? EnglishGroupId { get; set; }
    public EnglishGroup? EnglishGroup { get; set; } = null!;
    public int? SportClubId { get; set; }
    public SportClub? SportClub { get; set; } = null!;
    public int WeeklyHours { get; set; }
    public int TotalHours { get; set; }
    public bool TeacherIsCurrent { get; set; } = true;
    public string Comment { get; set; } = string.Empty;
}