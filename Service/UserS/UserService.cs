using AutoMapper;
using GameSpy.Data;
using GameSpy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace GameSpy.Service.UserS
{
    public class UserService : IUserService
    {
        private readonly IdentityContext _context;
        private readonly IMapper _mapper;

        public UserService(IdentityContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }
        public async Task AddUser(User user)
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

        public async Task<List<IdentityUser>> GetAllUsers()
        {

            var allUsers = await _context.Users.ToListAsync();

            return allUsers;
        }

        public async Task<IdentityUser> GetUserById(string id)
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

        public async Task UpdateUser(string id, User updatedUser)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(u => u.Id == id);


            try 
            {
                if (user == null)
                    throw new Exception("This user does not exist!!!");

                _mapper.Map<User, User>(updatedUser, (User)user);

                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
