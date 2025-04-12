namespace IThubSAT.Data;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}

// module rec SATDomain =

//     [<CLIMutable>]
//     type Discipline = {
//         DisciplineId: Int64
//         DisciplineName: string
//         DisciplineTypeId: Int64
//         IsOptional: Int64
//         DisciplineType: DisciplineType
//         Workloads: Workload seq
//     }

//     [<CLIMutable>]
//     type DisciplineType = {
//         DisciplineTypeId: Int64
//         DisciplineTypeName: string
//         Disciplines: Discipline seq
//         SurveysQuestions: SurveysQuestion seq
//     }

//     [<CLIMutable>]
//     type EnglishLevel = {
//         EnglishLevelId: Int64
//         EnglishLevelName: string
//         EnglishLevelsGroups: EnglishLevelsGroup seq
//     }

//     [<CLIMutable>]
//     type EnglishLevelsGroup = {
//         EnglishLevelsGroupsId: Int64
//         EnglishLevelId: Int64
//         GroupId: Int64
//         EnglishLevel: EnglishLevel
//         Group: Group
//     }

//     [<CLIMutable>]
//     type Faculty = {
//         FacultyId: Int64
//         FacultyName: string
//         Groups: Group seq
//     }

//     [<CLIMutable>]
//     type Group = {
//         GroupId: Int64
//         FacultyId: Int64
//         GroupName: string
//         StudyYear: Int64 option
//         Faculty: Faculty
//         EnglishLevelsGroups: EnglishLevelsGroup seq
//         Workloads: Workload seq
//     }

//     [<CLIMutable>]
//     type Survey = {
//         SurveyId: Int64
//         CreatedByUser: Int64
//         IsOpen: Int64
//         SurveyCreatedAt: string
//         SurveyDescription: string
//         SurveyEndDate: string
//         SurveyName: string
//         SurveyStartDate: string
//         CreatedByUserNavigation: User
//         SurveyEntries: SurveyEntry seq
//         SurveysQuestions: SurveysQuestion seq
//         SurveysWorkloads: SurveysWorkload seq
//         UsersRespondedToSurveys: UsersRespondedToSurvey seq
//     }

//     [<CLIMutable>]
//     type SurveyAnswer = {
//         SurveyAnswerId: Int64
//         SurveyAnswerData: string
//         SurveyEntryId: Int64
//         SurveyQuestionId: Int64
//         WorkloadDataId: Int64
//         SurveyEntry: SurveyEntry
//         SurveyQuestion: SurveyQuestion
//         WorkloadData: Workload
//     }

//     [<CLIMutable>]
//     type SurveyEntry = {
//         SurveyEnrtyId: Int64
//         GroupId: Int64
//         SurveyEntrySubmittedAt: string
//         SurveyId: Int64
//         Survey: Survey
//         SurveyAnswers: SurveyAnswer seq
//     }

//     [<CLIMutable>]
//     type SurveyQuestion = {
//         SurveyQuestionId: Int64
//         SurveyQuestionIsRequired: Int64
//         SurveyQuestionType: Int64
//         SurveyQuestionWording: string
//         SurveyQuestionTypeNavigation: SurveyQuestionType
//         SurveyAnswers: SurveyAnswer seq
//         SurveysQuestions: SurveysQuestion seq
//     }

//     [<CLIMutable>]
//     type SurveyQuestionType = {
//         SurveyQuestionTypeId: Int64
//         SurveyQuestionTypeName: string
//         SurveyQuestions: SurveyQuestion seq
//     }

//     [<CLIMutable>]
//     type SurveysQuestion = {
//         SurveysQuestionsId: Int64
//         SurveyId: Int64
//         SurveyQuestionId: Int64
//         VisibleForDisciplineTypeId: Int64
//         Survey: Survey
//         SurveyQuestion: SurveyQuestion
//         VisibleForDisciplineType: DisciplineType
//     }

//     [<CLIMutable>]
//     type SurveysWorkload = {
//         SurveysWorkloadsId: Int64
//         SurveyId: Int64
//         WorkloadId: Int64
//         Survey: Survey
//         Workload: Workload
//     }

//     [<CLIMutable>]
//     type Teacher = {
//         TeacherId: Int64
//         TeacherFirstName: string
//         TeacherLastName: string
//         TeacherPaternalName: string
//         Workloads: Workload seq
//     }

//     [<CLIMutable>]
//     type User = {
//         UserId: Int64
//         UserEmail: string
//         UserName: string
//         UserPasswordHash: string
//         UserTypeId: Int64
//         UserType: UserType
//         Surveys: Survey seq
//         UsersRespondedToSurveys: UsersRespondedToSurvey seq
//     }

//     [<CLIMutable>]
//     type UserType = {
//         UserTypeId: Int64
//         UserTypeName: string
//         Users: User seq
//     }

//     [<CLIMutable>]
//     type UsersRespondedToSurvey = {
//         UserSurveyShipId: Int64
//         SurveyId: Int64
//         UserId: Int64
//         Survey: Survey
//         User: User
//     }

//     [<CLIMutable>]
//     type Workload = {
//         WorkloadId: Int64
//         DisciplineId: Int64
//         GroupId: Int64
//         IsOptional: Int64 option
//         TeacherId: Int64
//         TeacherIsCurrent: Int64 option
//         TotalHours: Int64 option
//         WeeklyHours: Int64 option
//         Discipline: Discipline
//         Group: Group
//         Teacher: Teacher
//         SurveyAnswers: SurveyAnswer seq
//         SurveysWorkloads: SurveysWorkload seq
//     }

