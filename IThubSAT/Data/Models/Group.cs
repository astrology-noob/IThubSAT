namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class Group
{   
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public int StudentsInGroup { get; set; }
    public int StudyYear { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; } = null!;
}