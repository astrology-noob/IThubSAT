namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Workload
{   
    [Key]
    public int Id { get; set; } 
    public int? SurveyId { get; set; }
    public Survey? Survey { get; set; } = null!;
    public Group Group { get; set; } = null!;
    public Discipline Discipline { get; set; } = null!;
    public Teacher Teacher { get; set; } = null!;
    public int WeeklyHours { get; set; }
    public int TotalHours { get; set; }
    public bool TeacherIsCurrent { get; set; } = true;
}