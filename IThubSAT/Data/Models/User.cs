using System.ComponentModel.DataAnnotations;
namespace IThubSAT.Data.Models;

public class User
{   
    [Key]
    public int Id { get; set; } 
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public int UserTypeId { get; set; }
    public UserType UserType { get; set; } = null!;
    public List<UserRespondedToSurvey> UserRespondedToSurveys { get; } = [];
}