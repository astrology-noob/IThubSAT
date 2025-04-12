namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Group
{   
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public int StudyYear { get; set; }
    public Faculty Faculty { get; set; } = null!;
}