namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class User
{   
    [Key]
    public int Id { get; set; } 
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserType UserType { get; set; } = null!;
    public List<UserRespondedToSurvey> UserRespondedToSurveys { get; } = [];
}