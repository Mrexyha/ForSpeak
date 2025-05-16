using DAL.Entities.Languages;
using DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.UserLanguages) 
                .ToListAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<UserEntity> GetUserWithLanguagesAsync(int userId)
        {
            return await _context.Users
                .Include(u => u.UserLanguages)
                    .ThenInclude(ul => ul.Language)
                        .ThenInclude(l => l.Lessons)       
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<UserEntity> UpdateUserAsync(UserEntity user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {

            if (user.UserLanguages == null || !user.UserLanguages.Any())
            {
                user.UserLanguages = user.UserLanguages ?? new List<UserLanguage>();
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<int> GetUserPointsForLanguageAsync(int userId, int languageId)
        {
            return await _context.UsersToLessons
                .Where(ul => ul.UserId == userId && ul.Lesson.LanguageId == languageId)
                .SumAsync(ul => ul.AwardedPoints);
        }

        public async Task<int> GetUserTotalPointsAsync(int userId)
        {
            return await _context.UsersToLessons
                .Where(ul => ul.UserId == userId)
                .SumAsync(ul => ul.AwardedPoints);
        }
    }
}
