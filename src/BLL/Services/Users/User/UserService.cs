using AutoMapper;
using BLL.Models.User;
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

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> UpdateUserAsync(UserModel userModel)
        {
            var userEntity = _mapper.Map<UserEntity>(userModel);
            var updatedUser = await _userRepository.UpdateUserAsync(userEntity);
            return _mapper.Map<UserModel>(updatedUser);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }

        //public async Task<UserModel> SignUp(UserModel userModel)
        //{
        //    var existingUser = await _userRepository.GetUserByEmailAsync(userModel.Email);
        //    if (existingUser != null)
        //    {
        //        throw new Exception("Користувач з такою електронною поштою вже існує.");
        //    }

        //    var userEntity = _mapper.Map<UserEntity>(userModel);

        //    userEntity.PasswordHash = HashPassword(userModel.PasswordHash);

        //    var createdUser = await _userRepository.CreateUserAsync(userEntity);

        //    return _mapper.Map<UserModel>(createdUser);
        //}

        //private string HashPassword(string password)
        //{
        //    return BCrypt.Net.BCrypt.HashPassword(password);
        //}
    }
}
