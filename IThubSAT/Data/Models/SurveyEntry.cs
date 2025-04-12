namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class SurveyEntry
{   
    [Key]
    public int Id { get; set; }
    public Survey Survey { get; set; } = null!;
    public Group Group { get; set; } = null!;
    public string SubmittedAt { get; set; } = string.Empty;
}