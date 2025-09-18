namespace IThubSAT.Data;
using IThubSAT.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
public class FilterItem
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public FilterType FilterType {  get; set; }
}

public enum FilterType
{
    Discipline,
    Teacher,
    Faculty,
    StudyYear,
    EnglishGroup,
    SportClub,
    Group,
    QuestionType
}

public class SurveyService
{
    private static AppDbContext _dbContext = null!;

    public SurveyService(AppDbContext db) { _dbContext = db; }

    public static async Task SaveChanges() => await _dbContext.SaveChangesAsync();
 
    public static async Task<List<Survey>> GetSurveys() => await _dbContext.Surveys.ToListAsync();

    public static async Task<Survey?> GetSurveyByIdAsync(int SurveyId) =>
        await _dbContext.Surveys.Include(s => s.Chapters).ThenInclude(s => s.Questions).Where(s => s.Id == SurveyId).FirstOrDefaultAsync();

    public static async Task<int> AddSurveyAsync(Survey survey)
    {
        // автоматически создавать 3 главы и добавлять их в опрос

        survey.CreatedBy = GetSingleUser();
        
        Chapter chapterGeneral = new Chapter() { DisciplineType = DisciplineType.General, Name = "Общие дисциплины" };
        Chapter chapterEnglish = new Chapter() { DisciplineType = DisciplineType.English, Name = "Иностранный язык" };
        Chapter chapterSport = new Chapter() { DisciplineType = DisciplineType.Sport, Name = "Спортивные клубы" };
        survey.Chapters = [chapterGeneral, chapterEnglish, chapterSport];

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

    public static async Task<Chapter> DeleteChapterAsync(Chapter chapter)
    {
        _dbContext.Chapters.Remove(chapter);
        await SaveChanges();

        return chapter;
    }

    public static async Task<Question> DeleteQuestionAsync(Question question)
    {
        _dbContext.Questions.Remove(question);
        await SaveChanges();

        return question;
    }

    /// <summary>
    /// Gets the list of workloads including Teachers, Groups, Disciplines
    /// </summary>
    /// <param name="surveyId"></param>
    /// <returns></returns>
    public static async Task<List<Workload>> GetWorkloadBySurveyId(int surveyId) =>
        (await _dbContext.Surveys.Include(s => s.Workloads).ThenInclude(w => w.Teacher)
                                    .Include(s => s.Workloads).ThenInclude(w => w.Group).ThenInclude(g => g != null ? g.Faculty : null)
                                    .Include(s => s.Workloads).ThenInclude(w => w.Discipline)
                                    .Where(s => s.Id == surveyId).FirstOrDefaultAsync())?.Workloads ?? [];

    public static async Task<List<Workload>> GetSportClubsBySurveyId(int surveyId) =>
        await _dbContext.Workloads.Include(w => w.Discipline).Include(w => w.Teacher)
            .Where(w => w.SurveyId == surveyId && w.Discipline.DisciplineType == DisciplineType.Sport).ToListAsync();

    // вообще возможно не понадобится
    //public static async Task<List<Question>> GetQuestionsBySurveyId(int surveyId) => await _dbContext.Questions.Where(q => q.SurveyId == surveyId).ToListAsync();
    public static async Task<List<Question>> GetQuestionsByChapterId(int chapterId) 
        => await _dbContext.Questions.Where(q => q.ChapterId == chapterId).ToListAsync();

    // метод для проверки дублирующейся нагрузки (если уже есть набор дисциплина+(группа/подгруппа/клуб)+преподаватель)
    public static async Task<Workload?> GetSpecificWorkload(Group group, Discipline discipline, Teacher teacher) =>
        await _dbContext.Workloads.FirstOrDefaultAsync(x => x.Group == group && x.Discipline == discipline && x.Teacher == teacher);
    // у английского отдельный прикол - а, нет, будем считать что подгруппа это идентификатор и по нему искать.
    // нет, это всё-таки проблема. если уровень и уч. группа и препод одинаковые, то отличить подгруппы друг от друга нельзя, а соответственно и определить какую из них выбрал студент.
    // дубляжа по уч. группе, преподу и уровню быть не должно
    public static async Task<Workload?> GetSpecificWorkload(EnglishGroup englishGroup, EnglishLevel englishLevel, Discipline discipline, Teacher teacher) =>
        await _dbContext.Workloads.FirstOrDefaultAsync(x => x.EnglishGroup == englishGroup && x.EnglishGroup!.EnglishLevel == englishLevel && x.Discipline == discipline && x.Teacher == teacher);
    
    public static async Task<Workload?> GetSpecificWorkload(SportClub sportClub, Discipline discipline, Teacher teacher) =>
        await _dbContext.Workloads.FirstOrDefaultAsync(x => x.SportClub == sportClub && x.Discipline == discipline && x.Teacher == teacher);

    public static async Task<List<Group>> GetGroupsBySurveyId(int surveyId) =>
    await _dbContext.Workloads.Include(w => w.Group).Where(w => w.SurveyId == surveyId)
                                .Select(w => w.Group!).Distinct().ToListAsync();

    // это для фильтров
    // здесь может каким-то образом получать не прям объекты а id + конкретные поля?
    #region filters
    public static async Task<List<FilterItem>?> GetGroupsFilterItems(int surveyId) =>
        await _dbContext.Workloads.Where(w => w.SurveyId == surveyId).Where(w => w.GroupId != null).Select(w => w.Group!).Distinct()
                                    .Select(g => new FilterItem() { Id = g.Id, Name = g.Name, FilterType = FilterType.Group }).Distinct().ToListAsync();

    public static async Task<List<FilterItem>?> GetEnglishLevelsFilterItems(int surveyId) =>
        await _dbContext.Workloads.Where(w => w.SurveyId == surveyId).Where(w => w.EnglishGroupId != null).Select(w => w.EnglishGroup!).Distinct()
                                    .Select(e => new FilterItem() { Id = e.Id, Name = e.EnglishLevel!.Name, FilterType = FilterType.EnglishGroup }).Distinct().ToListAsync();

    public static async Task<List<FilterItem>?> GetSportClubsFilterItems(int surveyId) =>
        await _dbContext.Workloads.Where(w => w.SurveyId == surveyId).Where(w => w.SportClubId != null).Select(w => w.SportClub!).Distinct()
                                    .Select(s => new FilterItem() { Id = s.Id, Name = s.Name, FilterType = FilterType.SportClub }).ToListAsync();

    public static async Task<List<FilterItem>?> GetDisciplinesFilterItems(int surveyId) =>
        await _dbContext.Workloads.Include(w => w.Discipline!).Where(w => w.SurveyId == surveyId)
                                    .Select(w => new FilterItem() { Id = w.Discipline!.Id, Name = w.Discipline!.Name, FilterType = FilterType.Discipline }).Distinct().ToListAsync();

    public static async Task<List<FilterItem>?> GetTeachersFilterItems(int surveyId) =>
        await _dbContext.Workloads.Include(w => w.Teacher!).Where(w => w.SurveyId == surveyId)
                                    .Select(w => new FilterItem() { Id = w.Teacher!.Id, Name = w.Teacher!.FullName, FilterType = FilterType.Teacher }).Distinct().ToListAsync();

    public static async Task<List<FilterItem>?> GetFacultiesFilterItems(int surveyId) =>
        await _dbContext.Workloads.Where(w => w.SurveyId == surveyId && w.Group != null).Select(w => w.Group)
                                    .Select(g => new FilterItem() { Id = g.FacultyId, Name = g.Faculty.Name, FilterType = FilterType.Faculty }).Distinct().ToListAsync();

    public static async Task<List<FilterItem>> GetStudyYearsFilterItems(int surveyId) =>
        await _dbContext.Workloads.Where(w => w.SurveyId == surveyId && w.Group != null).Select(w => w.Group)
                                    .Select(g => new FilterItem() { Id = g.StudyYear, Name = g.StudyYear.ToString(), FilterType = FilterType.StudyYear }).Distinct().ToListAsync();
    #endregion

    public static async Task<List<Workload>> GetWorkloadsBySurveyIdAndStudyGroupId(int SurveyId, int GroupId) =>
        await _dbContext.Workloads.Include(w => w.Discipline).Where(w => w.SurveyId == SurveyId && w.GroupId == GroupId).ToListAsync();
    
    public static User GetSingleUser() => _dbContext.Users.FirstOrDefault() ?? new();
    public static async Task<Group?> GetGroupByName(string name) => await _dbContext.Groups.FirstOrDefaultAsync(x => x.Name == name);
    public static async Task<EnglishGroup?> GetEnglishGroupByName(string name) => await _dbContext.EnglishGroups.FirstOrDefaultAsync(x => x.Name == name);
    public static async Task<SportClub?> GetSportClubByName(string name) => await _dbContext.SportClubs.FirstOrDefaultAsync(x => x.Name == name);
    public static async Task<EnglishLevel?> GetEnglishLevelByName(string name) => await _dbContext.EnglishLevels.FirstOrDefaultAsync(x => x.Name == name);
    public static async Task<Discipline?> GetDisciplineByName(string name) => await _dbContext.Disciplines.FirstOrDefaultAsync(x => x.Name == name);
    public static async Task<Faculty?> GetFacultyByName(string name) => await _dbContext.Faculties.FirstOrDefaultAsync(x => x.Name == name);
    public static async Task<Teacher?> GetTeacherByFio(string[] fio) => await _dbContext.Teachers.FirstOrDefaultAsync(x => x.LastName == fio[0] && x.FirstName == fio[1] && x.PaternalName == fio[2]);

    public static async Task AddNewGroup(Group group) => await _dbContext.Groups.AddAsync(group);
    public static async Task AddNewEnglishGroup(EnglishGroup englishGroup) => await _dbContext.EnglishGroups.AddAsync(englishGroup);
    public static async Task AddNewSportClub(SportClub sportClub) => await _dbContext.SportClubs.AddAsync(sportClub);
    public static async Task AddNewEnglishLevel(EnglishLevel englishLevel) => await _dbContext.EnglishLevels.AddAsync(englishLevel);
    public static async Task AddNewDiscipline(Discipline discipline) => await _dbContext.Disciplines.AddAsync(discipline);
    public static async Task AddNewTeacher(Teacher teacher) => await _dbContext.Teachers.AddAsync(teacher);
    public static async Task AddNewFaculty(Faculty faculty) => await _dbContext.Faculties.AddAsync(faculty);
    public static async Task AddNewWorkload(Workload workload) => await _dbContext.Workloads.AddAsync(workload);

    public static void UpdateWorkload(Workload workload) => _dbContext.Workloads.Update(workload);

    public static async Task<string> PerformTransaction()
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return string.Empty;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return $"An error occurred while saving changes: {ex.Message}";
            }
        }
    }
}