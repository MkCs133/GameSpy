using AutoMapper;
using GameSpy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace GameSpy.Service.UserS
{
    public class UserService : IUserService
    {
        private readonly GameSpyContext _context;
        private readonly IMapper _mapper;

        public UserService(GameSpyContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }
        public async Task AddUser(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteUser(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            try {
                if (user == null)
                {
                    throw new Exception(@"User with this Id does not exist!!!");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex) {
                throw new Exception(ex.Message);            
            }
        }

        public async Task<List<Achievement>> GetAchievements(string id)
        {
            List<Achievement> allAchievements = await _context.Achievements.ToListAsync();

            var userAchievementList = await _context.UsersAchievements.ToListAsync();
            var achievementUserListById = new List<UsersAchievements>();

            List<Achievement> usersAchievements = new List<Achievement>();

            foreach (UsersAchievements achievement in userAchievementList)
            {
                if (achievement.Userid == id)
                {
                    achievementUserListById.Add(achievement);
                }
            }

            foreach (Achievement achievement in allAchievements)
            {
                foreach (UsersAchievements usersId in achievementUserListById)
                {
                    if (achievement.Achievementsid == usersId.Achievementid)
                    {
                        usersAchievements.Add(achievement);
                    }
                }
            }

            return usersAchievements;

        }

        public async Task<List<AppUser>> GetAllUsers()
        {

            var allUsers = await _context.Users.ToListAsync();

            return allUsers;
        }

        public async Task<AppUser> GetUserById(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            try {
                if (user == null)
                    throw new Exception(@"User with this id does not exist!!!");
                return user;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUser(string id, AppUser updatedUser)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            

            try 
            {
                if (user == null)
                    throw new Exception("This user does not exist!!!");

                _mapper.Map<AppUser, AppUser>(updatedUser, user);

                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
