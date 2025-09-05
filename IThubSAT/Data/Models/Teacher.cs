using System.ComponentModel.DataAnnotations;
namespace IThubSAT.Data.Models;

public class Teacher
{   
    [Key]
    public int Id { get; set; } 
    public string LastName { get; set; } = "Новый";
    public string FirstName { get; set; } = "Преподаватель";
    public string PaternalName { get; set; } = "Преподавателев";

    public string FullName => string.Join(' ', LastName, FirstName, PaternalName);
}