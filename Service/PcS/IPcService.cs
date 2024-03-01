using GameSpy.Models;
using Microsoft.AspNetCore.Identity;

namespace GameSpy.Service.PcS
{
    public interface IPcService
    {
        Task<Pc> GetPcById(int id);
        Task<List<Pc>> GetAllPcs();
        Task UpdatePc(int id, Pc newPc);
        Task DeletePc(int id);
        Task AddPc(Pc pc);
    }
}
