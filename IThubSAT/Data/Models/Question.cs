namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class Question
{   
    [Key]
    public int Id { get; set; } 
    public string Text { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public QuestionType QuestionType { get; set; } = null!;
}