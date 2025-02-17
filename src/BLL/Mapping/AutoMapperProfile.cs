using AutoMapper;
using BLL.Models.Languages;
using BLL.Models.User;
using DAL.Entities.Languages;
using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, UserEntity>()
                .ForMember(dest => dest.UserLanguages, opt => opt.Ignore());

            CreateMap<UserLanguageModel, UserLanguage>().ReverseMap();

            CreateMap<UserLanguageModel, UserLanguage>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
