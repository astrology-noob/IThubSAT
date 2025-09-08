using System.ComponentModel.DataAnnotations;
namespace IThubSAT.Data.Models;

public class Question
{   
    [Key]
    public int Id { get; set; } 
    public string Text { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public int ChapterId { get; set; }
    public Chapter Chapter { get; set; } = null!;
    public QuestionType QuestionType { get; set; }
    // в целом здесь можно json хранить, а обрабатывать в конкретном компоненте с описанной моделькой (+ получать сериализованную строку из этой модельки)
    public string QuestionTypeInfo { get; set; } = string.Empty;
}

public enum QuestionType
{
    Scale = 1,
    ShortText = 2,
    LongText = 3,
    SingleChoice = 4,
    MultipleChoice = 5,
}