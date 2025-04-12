namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class UserType
{   
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
}