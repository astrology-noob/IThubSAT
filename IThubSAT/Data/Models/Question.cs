using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IThubSAT.Data.Models;

public class Question
{   
    [Key]
    public int Id { get; set; } 
    public string Text { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public int SectionId { get; set; }
    public Section Section { get; set; } = null!;
    public QuestionType QuestionType { get; set; }
    // в целом здесь можно json хранить, а обрабатывать в конкретном компоненте с описанной моделькой (+ получать сериализованную строку из этой модельки)
    public string QuestionTypeInfo { get; set; } = string.Empty;
}

public enum QuestionType
{
    Scale = 1,
    SingleChoice = 2,
    MultipleChoice = 3,
    ShortText = 4,
    LongText = 5
}