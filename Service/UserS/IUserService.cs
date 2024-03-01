using GameSpy.Models;
using Microsoft.AspNetCore.Identity;

namespace GameSpy.Service.UserS
{
    public interface IUserService
    {
        Task<IdentityUser> GetUserById(string id);
        Task<List<IdentityUser>> GetAllUsers();
        Task UpdateUser(string id, User updatedUser);
        Task DeleteUser(string id);
        Task AddUser(User user);


    }
}
