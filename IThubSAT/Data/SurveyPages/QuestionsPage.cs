using IThubSAT.Data.Models;

namespace IThubSAT.Data
{
    public class QuestionsPage : SurveyPage
    {
        public Workload Workload { get; set; } = null!;

        public List<Question> Questions { get; set; } = null!;

        public string DisciplineName = null!;
    }
}
