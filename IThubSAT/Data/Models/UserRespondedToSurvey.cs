namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class UserRespondedToSurvey
{   
    [Key]
    public int Id { get; set; } 
    public int UserId { get; set; } 
    public User User { get; set; } = null!;
    public int SurveyId { get; set; } 
    public Survey Survey { get; set; } = null!;
}