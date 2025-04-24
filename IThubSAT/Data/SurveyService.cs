namespace IThubSAT.Data;
using IThubSAT.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SurveyService
{
    private AppDbContext _dbContext;

    public SurveyService(AppDbContext db)
    {
        _dbContext = db;
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    public List<Survey> GetSurveys()
    {
        return _dbContext.Surveys.ToList();
    }

    public async Task<Survey?> GetSurveyByIdAsync(int SurveyId)
    {
        return await _dbContext.Surveys
                                .Include(s => s.Questions)
                                    .ThenInclude(q => q.QuestionType)
                                .Include(s => s.Questions)
                                    .ThenInclude(q => q.DisciplineType)
                                .Where(s => s.Id == SurveyId)
                                .FirstOrDefaultAsync();
        // return survey;
    }

    public async Task<Survey> CreateSurveyAsync(Survey survey)
    {
        _dbContext.Surveys.Add(survey);
        await _dbContext.SaveChangesAsync();

        return survey;
    }

    public async Task<Survey> DeleteSurveyAsync(Survey survey)
    {
        _dbContext.Surveys.Remove(survey);
        await _dbContext.SaveChangesAsync();

        return survey;
    }

    public async Task<List<Workload>> GetWorkloadBySurveyId(int SurveyId)
    {
        Survey res = await _dbContext.Surveys
                                .Include(s => s.Workloads)
                                    .ThenInclude(w => w.Teacher)
                                .Include(s => s.Workloads)
                                    .ThenInclude(w => w.Group)
                                        .ThenInclude(g => g.Faculty)
                                .Include(s => s.Workloads)
                                    .ThenInclude(w => w.Discipline)
                                .Where(s => s.Id == SurveyId)
                                .FirstOrDefaultAsync() ?? new();
        return res.Workloads ?? new();
    }

    public async Task<List<Discipline>> GetDisciplinesOfSurvey(int SurveyId)
    {
        List<Discipline> res = await _dbContext.Workloads
                                    .Include(w => w.Discipline)
                                    .Where(w => w.SurveyId == SurveyId)
                                    .Select(w => w.Discipline)
                                    .ToListAsync();
        return res;
    }

    public async Task<List<Question>> GetQuestionsBySurveyId(int SurveyId)
    {
        List<Question> res = await _dbContext.Questions
                                    .Include(q => q.QuestionType)
                                    .Include(q => q.DisciplineType)
                                    .Where(q => q.SurveyId == SurveyId)
                                    .ToListAsync();
        return res;                 
    }

    public User GetSingleUser()
    {
        return _dbContext.Users.FirstOrDefault() ?? new();
    }
}