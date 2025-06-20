namespace IThubSAT.Data;
using IThubSAT.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SurveyService
{
    private static AppDbContext _dbContext;

    public SurveyService(AppDbContext db) { _dbContext = db; }

    public static async Task SaveChanges() => await _dbContext.SaveChangesAsync();
 
    public static async Task<List<Survey>> GetSurveys() => await _dbContext.Surveys.ToListAsync();

    public static async Task<Survey?> GetSurveyByIdAsync(int SurveyId) =>
        await _dbContext.Surveys.Include(s => s.Questions).ThenInclude(q => q.QuestionType)
                                .Include(s => s.Questions).ThenInclude(q => q.DisciplineType)
                                .Where(s => s.Id == SurveyId).FirstOrDefaultAsync();

    public static async Task<int> AddSurveyAsync(Survey survey)
    {
        survey.CreatedBy = GetSingleUser();
        _dbContext.Surveys.Add(survey);
        await _dbContext.SaveChangesAsync();

        return survey.Id;
    }

    public static async Task<Survey> DeleteSurveyAsync(Survey survey)
    {
        _dbContext.Surveys.Remove(survey);
        await SaveChanges();

        return survey;
    }

    public static async Task<List<Workload>> GetWorkloadBySurveyId(int surveyId) =>
        (await _dbContext.Surveys.Include(s => s.Workloads).ThenInclude(w => w.Teacher)
                                    .Include(s => s.Workloads).ThenInclude(w => w.Group).ThenInclude(g => g != null ? g.Faculty : null)
                                    .Include(s => s.Workloads).ThenInclude(w => w.Discipline)
                                    .Where(s => s.Id == surveyId).FirstOrDefaultAsync())?.Workloads ?? [];

    public static async Task<List<Question>> GetQuestionsBySurveyId(int surveyId) =>
        await _dbContext.Questions.Include(q => q.QuestionType).Include(q => q.DisciplineType)
                                    .Where(q => q.SurveyId == surveyId).ToListAsync();

    // нужен метод для проверки дублирующейся нагрузки (если уже есть набор дисциплина+группа+преподаватель)

    // здесь может каким-то образом получать не прям объекты а id + конкретные поля?
    public static async Task<List<Group>> GetGroupsBySurveyId(int surveyId) =>
        await _dbContext.Workloads.Include(w => w.Group).Where(w => w.SurveyId == surveyId)
                                    .Select(w => w.Group!).Distinct().ToListAsync();
    public static async Task<List<Teacher>> GetTeachersBySurveyId(int surveyId) =>
        await _dbContext.Workloads.Include(w => w.Teacher).Where(w => w.SurveyId == surveyId)
                                    .Select(w => w.Teacher!).Distinct().ToListAsync();

    public static async Task<List<Faculty>> GetFacultiesBySurveyId(int surveyId) =>
        await _dbContext.Workloads.Include(w => w.Group!.Faculty).Where(w => w.SurveyId == surveyId)
                                    .Select(w => w.Group!.Faculty).Distinct().ToListAsync();

    public static async Task<List<Workload>> GetWorkloadsBySurveyIdAndStudyGroupId(int SurveyId, int GroupId) =>
        await _dbContext.Workloads.Where(w => w.SurveyId == SurveyId && w.GroupId == GroupId).ToListAsync();
    
    public static User GetSingleUser() => _dbContext.Users.FirstOrDefault() ?? new();
    public static Group GetGroupByName(string name) => _dbContext.Groups.FirstOrDefault(x => x.Name == name) ?? new();
}