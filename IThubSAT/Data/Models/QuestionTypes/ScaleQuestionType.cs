namespace IThubSAT.Data.Models.QuestionTypes;

public class ScaleQuestionType
{
    // для валидации
    // минимальное максимум 0
    public int MinPoints = 1;
    // максимальное максимум 10
    public int MaxPoints = 5;
    public string MinPointsText = string.Empty;
    public string MaxPointsText = string.Empty;
}

