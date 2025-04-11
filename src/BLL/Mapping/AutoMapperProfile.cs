using AutoMapper;
using BLL.Models.Languages;
using BLL.Models.User;
using DAL.Entities.Languages;
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
            // UserEntity to LoginModel and reverse mapping
            CreateMap<UserEntity, LoginModel>().ReverseMap();

            // UserModel to UserEntity, ignoring UserLanguages here
            CreateMap<UserModel, UserEntity>()
                .ForMember(dest => dest.UserLanguages, opt => opt.Ignore());

            // Mapping UserLanguageModel to UserLanguage and reverse
            CreateMap<UserLanguageModel, UserLanguage>().ReverseMap();

            // UserLanguageModel to UserLanguage with ignored User field and reverse
            CreateMap<UserLanguageModel, UserLanguage>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ReverseMap();

            // UserEntity to UserModel and reverse
            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.SelectedLanguageIds, opt => opt.MapFrom(src =>
                    src.UserLanguages.Select(ul => ul.LanguageId).ToList()
                ))
                .ReverseMap();

            // RegisterModel to UserEntity (creating UserLanguages from SelectedLanguageIds)
            CreateMap<RegisterModel, UserEntity>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.UserLanguages, opt => opt.MapFrom(src =>
                    src.SelectedLanguageIds
                        .Select(id => new UserLanguage { LanguageId = id, Progress = 0 })
                        .ToList()
                ));

            // UserEntity to RegisterModel, mapping UserLanguages to SelectedLanguageIds
            CreateMap<UserEntity, RegisterModel>()
                .ForMember(dest => dest.SelectedLanguageIds, opt => opt.MapFrom(src =>
                    src.UserLanguages.Select(ul => ul.LanguageId).ToList()
                ));

            // LanguageEntity to LanguageModel and reverse
            CreateMap<LanguageEntity, LanguageModel>().ReverseMap();

            // UserLanguage to UserLanguageModel and reverse
            CreateMap<UserLanguage, UserLanguageModel>()
                .ForMember(d => d.Language, opt => opt.MapFrom(src => src.Language))
                .ReverseMap();

            // Mapping UserLanguageModel to int (for SelectedLanguageIds)
            CreateMap<UserLanguageModel, int>()
                .ConvertUsing(src => src.LanguageId); // Assuming UserLanguageModel has LanguageId

            // Reverse mapping (int to UserLanguageModel)
            CreateMap<int, UserLanguageModel>()
                .ConvertUsing(src => new UserLanguageModel { LanguageId = src });
        }
    }
}
