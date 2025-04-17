﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IThubSAT.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.13");

            modelBuilder.Entity("IThubSAT.Data.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnswerData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SurveyEntryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkloadId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SurveyEntryId");

                    b.HasIndex("WorkloadId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplineTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOptional")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineTypeId");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.DisciplineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DisciplineTypes");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.EnglishGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnglishLevelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EnglishLevelId");

                    b.HasIndex("GroupId");

                    b.ToTable("EnglishGroups");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.EnglishLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EnglishLevels");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudyYear")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplineTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SectionTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SurveyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineTypeId");

                    b.HasIndex("QuestionTypeId");

                    b.HasIndex("SectionTypeId");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("QuestionTypes");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.SectionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SectionTypes");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModifiedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.SurveyEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubmittedAt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SurveyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyEntries");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PaternalName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.UserRespondedToSurvey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SurveyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersRespondedToSurveys");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Workload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TeacherIsCurrent")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalHours")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeeklyHours")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Workloads");
                });

            modelBuilder.Entity("SurveyWorkload", b =>
                {
                    b.Property<int>("SurveysId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkloadsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SurveysId", "WorkloadsId");

                    b.HasIndex("WorkloadsId");

                    b.ToTable("SurveyWorkload");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Answer", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.SurveyEntry", "SurveyEntry")
                        .WithMany()
                        .HasForeignKey("SurveyEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.Workload", "Workload")
                        .WithMany()
                        .HasForeignKey("WorkloadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("SurveyEntry");

                    b.Navigation("Workload");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Discipline", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.DisciplineType", "DisciplineType")
                        .WithMany()
                        .HasForeignKey("DisciplineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DisciplineType");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.EnglishGroup", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.EnglishLevel", "EnglishLevel")
                        .WithMany()
                        .HasForeignKey("EnglishLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnglishLevel");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Group", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Question", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.DisciplineType", "DisciplineType")
                        .WithMany()
                        .HasForeignKey("DisciplineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.QuestionType", "QuestionType")
                        .WithMany()
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.SectionType", "SectionType")
                        .WithMany()
                        .HasForeignKey("SectionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DisciplineType");

                    b.Navigation("QuestionType");

                    b.Navigation("SectionType");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Survey", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.SurveyEntry", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.Survey", "Survey")
                        .WithMany()
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.User", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.UserRespondedToSurvey", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.Survey", "Survey")
                        .WithMany("UsersRespondedToSurvey")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.User", "User")
                        .WithMany("UserRespondedToSurveys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Workload", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Group");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SurveyWorkload", b =>
                {
                    b.HasOne("IThubSAT.Data.Models.Survey", null)
                        .WithMany()
                        .HasForeignKey("SurveysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThubSAT.Data.Models.Workload", null)
                        .WithMany()
                        .HasForeignKey("WorkloadsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IThubSAT.Data.Models.Survey", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("UsersRespondedToSurvey");
                });

            modelBuilder.Entity("IThubSAT.Data.Models.User", b =>
                {
                    b.Navigation("UserRespondedToSurveys");
                });
#pragma warning restore 612, 618
        }
    }
}
