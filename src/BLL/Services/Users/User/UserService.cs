using AutoMapper;
using BLL.Models.User;
using DAL.Entities.Languages;
using DAL.Entities.Users;
using DAL.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Users.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<RegisterModel>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<List<RegisterModel>>(users);
        }

        public async Task<RegisterModel> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<RegisterModel>(user);
        }

        public async Task<UserModel> GetUserWithLanguagesAsync(int userId)
        {
            var entity = await _userRepository.GetUserWithLanguagesAsync(userId);
            if (entity == null) return null;
            return _mapper.Map<UserModel>(entity);
        }

        public async Task<RegisterModel> UpdateUserAsync(RegisterModel userModel)
        {
            var userEntity = _mapper.Map<UserEntity>(userModel);
            var updatedUser = await _userRepository.UpdateUserAsync(userEntity);
            return _mapper.Map<RegisterModel>(updatedUser);
        }

        public async Task<bool> AddLanguageToUserAsync(int userId, int languageId)
        {
            var user = await _userRepository.GetUserWithLanguagesAsync(userId);
            if (user == null) return false;

            var alreadyExists = user.UserLanguages.Any(ul => ul.LanguageId == languageId);
            if (alreadyExists) return false;

            user.UserLanguages.Add(new UserLanguage
            {
                UserId = userId,
                LanguageId = languageId,
                Progress = 0
            });

            await _userRepository.UpdateUserAsync(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }
    }
}
