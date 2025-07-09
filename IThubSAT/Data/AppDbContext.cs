using Microsoft.EntityFrameworkCore;
using IThubSAT.Data.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Survey> Surveys { get; set; } = null!;
    public DbSet<Section> Sections { get; set; } = null!;
    public DbSet<Discipline> Disciplines { get; set; } = null!;
    public DbSet<EnglishLevel> EnglishLevels { get; set; } = null!;
    public DbSet<Faculty> Faculties { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<UserType> UserTypes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Workload> Workloads { get; set; } = null!;
    public DbSet<SurveyEntry> SurveyEntries { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;
    public DbSet<SportClub> SportClubs { get; set; } = null!;
    public DbSet<EnglishGroup> EnglishGroups { get; set; } = null!;
    public DbSet<UserRespondedToSurvey> UsersRespondedToSurveys { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Discipline>()
            .Property(x => x.DisciplineType)
            .HasConversion<int>();

        modelBuilder
            .Entity<Question>()
            .Property(x => x.QuestionType)
            .HasConversion<int>();

        base.OnModelCreating(modelBuilder);
    }
}