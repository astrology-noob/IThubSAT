namespace IThubSAT.Data.Models;
using System.ComponentModel.DataAnnotations;
public class QuestionType
{   
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public string TypeInfoMask { get; set; } = string.Empty;
}