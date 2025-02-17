using AutoMapper;
using BCrypt.Net;
using BLL.Models.User;
using BLL.Services.Users.JWT;
using DAL.Repositories.Users;
using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities.Languages;

namespace BLL.Services.Users.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository, IJwtService jwtService, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<string> Register(UserModel userModel)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(userModel.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            if (userModel.PasswordHash != userModel.ConfirmPassword)
            {
                throw new Exception("Passwords do not match");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userModel.PasswordHash);

            var newUser = _mapper.Map<UserEntity>(userModel);
            newUser.PasswordHash = passwordHash;

            var createdUser = await _userRepository.CreateUserAsync(newUser);
            return _jwtService.GenerateToken(_mapper.Map<UserModel>(createdUser));
        }

        public async Task<string> Login(UserModel user)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.PasswordHash, existingUser.PasswordHash))
            {
                throw new Exception("Invalid credentials");
            }

            var userModel = _mapper.Map<UserModel>(existingUser);
            return _jwtService.GenerateToken(userModel);
        }
    }
}
