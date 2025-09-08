using IThubSAT.Data.Models;

namespace IThubSAT.Data
{
    public class QuestionsPage : SurveyPage
    {
        public List<Question> Questions { get; set; }

        public string DisciplineName;
    }
}
