using AutoMapper;
using BLL.Models.Languages;
using BLL.Models.Lessons;
using BLL.Models.Modules;
using BLL.Models.Tasks;
using BLL.Models.User;
using DAL.Entities.Languages;
using DAL.Entities.Lessons;
using DAL.Entities.Modules;
using DAL.Entities.Tasks;
using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // ========== USER MAPPING ==========
            CreateMap<UserEntity, LoginModel>().ReverseMap();

            CreateMap<UserModel, UserEntity>()
                .ForMember(dest => dest.UserLanguages, opt => opt.Ignore());

            CreateMap<UserLanguageModel, UserLanguage>().ReverseMap();

            CreateMap<UserLanguageModel, UserLanguage>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.SelectedLanguageIds, opt => opt.MapFrom(src =>
                    src.UserLanguages.Select(ul => ul.LanguageId).ToList()
                ))
                .ReverseMap();

            CreateMap<RegisterModel, UserEntity>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.UserLanguages, opt => opt.MapFrom(src =>
                    src.SelectedLanguageIds
                        .Select(id => new UserLanguage { LanguageId = id, Progress = 0 })
                        .ToList()
                ));

            CreateMap<UserEntity, RegisterModel>()
                .ForMember(dest => dest.SelectedLanguageIds, opt => opt.MapFrom(src =>
                    src.UserLanguages.Select(ul => ul.LanguageId).ToList()
                ));

            CreateMap<UserLanguage, UserLanguageModel>()
                .ForMember(d => d.Language, opt => opt.MapFrom(src => src.Language))
                .ReverseMap();

            CreateMap<UserLanguageModel, int>()
                .ConvertUsing(src => src.LanguageId);

            CreateMap<int, UserLanguageModel>()
                .ConvertUsing(src => new UserLanguageModel { LanguageId = src });

            // ========== LANGUAGE & LESSON MAPPING ==========
            CreateMap<LanguageEntity, LanguageModel>()
                .ForMember(dest => dest.LessonsCount,
                    opt => opt.MapFrom(src => src.Lessons.Count))
                .ReverseMap();

            CreateMap<LessonEntity, LessonModel>().ReverseMap();

            // ========== THEORY MODULE ==========
            CreateMap<TheoryModuleEntity, TheoryModuleModel>().ReverseMap();

            // ========== VOCABULARY MODULE ==========
            CreateMap<VocabularyModuleEntity, VocabularyModuleModel>().ReverseMap();
            CreateMap<WordEntity, WordModel>().ReverseMap();

            // ========== QUIZ MODULE ==========
            CreateMap<QuizModuleEntity, QuizModuleModel>().ReverseMap();
            CreateMap<QuizQuestionEntity, QuizQuestionModel>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src =>
                    new List<string> { src.Option1, src.Option2, src.Option3 }))
                .ReverseMap()
                .ForMember(dest => dest.Option1, opt => opt.MapFrom(src => src.Options[0]))
                .ForMember(dest => dest.Option2, opt => opt.MapFrom(src => src.Options[1]))
                .ForMember(dest => dest.Option3, opt => opt.MapFrom(src => src.Options[2]));

            // ========== READING MODULE ==========
            CreateMap<ReadingModuleEntity, ReadingModuleModel>().ReverseMap();
            CreateMap<FillInTheBlankTaskEntity, FillInTheBlankTaskModel>().ReverseMap();

            // ========== SPEAKING MODULE ==========
            CreateMap<SpeakingModuleEntity, SpeakingModuleModel>().ReverseMap();
            CreateMap<SpeakingPhraseEntity, SpeakingPhraseModel>().ReverseMap();

            // ========== TASKS ==========
            CreateMap<TaskLangModel, TaskLangEntity>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TaskType));
            CreateMap<TaskLangEntity, TaskLangModel>()
                .ForMember(dest => dest.TaskType, opt => opt.MapFrom(src => src.Type));

            CreateMap<TheoryModuleEntity, TheoryModuleModel>().ReverseMap();
        }
    }
}
