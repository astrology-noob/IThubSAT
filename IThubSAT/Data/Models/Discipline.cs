using System.ComponentModel.DataAnnotations;
namespace IThubSAT.Data.Models;

public class Discipline
{   
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "Новая дисциплина";
    public DisciplineType DisciplineType { get; set; }
    public bool IsOptional { get; set; }
}

// вместо типа дисциплины можно использовать и таблицу наверное уже, тк секции у меня теперь создаются по конкретному одному типу дисциплины
// а, а может сразу создавать секции для всех типов дисциплин? Их же всего 4, а редактировать там не особо много просто
public enum DisciplineType
{
    General = 1,
    English = 2,
    Sport = 3
}