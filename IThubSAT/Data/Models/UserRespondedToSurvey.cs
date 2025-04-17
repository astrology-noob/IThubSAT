namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class UserRespondedToSurvey
{   
    [Key]
    public int Id { get; set; } 
    public int UserId { get; set; } 
    public int SurveyId { get; set; } 
    public User User { get; set; } = null!;
    public Survey Survey { get; set; } = null!;
}