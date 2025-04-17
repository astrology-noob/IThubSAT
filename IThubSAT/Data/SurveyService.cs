namespace IThubSAT.Data;
using IThubSAT.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        return await _dbContext.Surveys.Where(s => s.Id == SurveyId).FirstOrDefaultAsync();
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

    public List<Workload> GetWorkloadBySurveyId(int SurveyId)
    {
        // _dbContext.Workloads.Remove(survey);
        // await _dbContext.SaveChangesAsync();

        return new List<Workload>();
    }

    public User GetSingleUser()
    {
        return _dbContext.Users.FirstOrDefault();
    }
}