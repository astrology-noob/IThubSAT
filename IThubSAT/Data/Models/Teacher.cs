namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class Teacher
{   
    [Key]
    public int Id { get; set; } 
    public string LastName { get; set; } = "Новый";
    public string FirstName { get; set; } = "Преподаватель";
    public string PaternalName { get; set; } = "Преподавателевич";

    public string FullName => string.Join(' ', LastName, FirstName, PaternalName);
}