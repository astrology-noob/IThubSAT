using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IThubSAT.Data.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Survey> Surveys { get; set; } = null!;
    public DbSet<DisciplineType> DisciplineTypes { get; set; } = null!;
    public DbSet<Discipline> Disciplines { get; set; } = null!;
    public DbSet<EnglishLevel> EnglishLevels { get; set; } = null!;
    public DbSet<Faculty> Faculties { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<QuestionType> QuestionTypes { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<UserType> UserTypes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Workload> Workloads { get; set; } = null!;
    public DbSet<UserRespondedToSurvey> UsersRespondedToSurveys { get; set; } = null!;
    public DbSet<WorkloadInSurvey> WorkloadsInSurveys { get; set; } = null!;
    public DbSet<QuestionInSurvey> QuestionsInSurveys { get; set; } = null!;
    public DbSet<SurveyEntry> SurveyEntries { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;
    public DbSet<EnglishGroup> EnglishGroups { get; set; } = null!;
}