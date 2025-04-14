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
using Azure.Core;

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

        public async Task<AuthResult> Register(RegisterModel userModel)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(userModel.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            if (!string.IsNullOrEmpty(userModel.ConfirmPassword) && userModel.Password != userModel.ConfirmPassword)
            {
                throw new Exception("Passwords do not match");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userModel.Password);

            var newUser = _mapper.Map<UserEntity>(userModel);
            newUser.PasswordHash = passwordHash;

            var createdUser = await _userRepository.CreateUserAsync(newUser);

            var token = _jwtService.GenerateToken(_mapper.Map<UserModel>(createdUser));
            return new AuthResult { Token = token, UserId = createdUser.Id };
        }

        public async Task<AuthResult> Login(LoginModel loginModel)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(loginModel.Email);
            if (existingUser == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginModel.Password, existingUser.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            var token = _jwtService.GenerateToken(_mapper.Map<UserModel>(existingUser));

            return new AuthResult
            {
                Token = token,
                UserId = existingUser.Id
            };
        }
    }
}
