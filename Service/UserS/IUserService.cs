using GameSpy.Models;
using Microsoft.AspNetCore.Identity;

namespace GameSpy.Service.UserS
{
    public interface IUserService
    {
        Task<AppUser> GetUserById(string id);
        Task<List<AppUser>> GetAllUsers();
        Task UpdateUser(string id, AppUser updatedUser);
        Task DeleteUser(string id);
        Task AddUser(AppUser user);


    }
}
