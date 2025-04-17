namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class QuestionInSurvey
{   
    [Key]
    public int Id { get; set; } 
    public Question Question { get; set; } = null!;
    public Survey Survey { get; set; } = null!;
    public DisciplineType VisibleForDisciplineType { get; set; } = null!;
}