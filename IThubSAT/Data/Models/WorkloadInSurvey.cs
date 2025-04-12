namespace IThubSAT.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class WorkloadInSurvey
{   
    [Key]
    public int Id { get; set; } 
    public Workload Workload { get; set; } = null!;
    public Survey Survey { get; set; } = null!;
}