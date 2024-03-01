using AutoMapper;
using GameSpy.Data;
using GameSpy.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSpy.Service.PcS
{
    public class PcService : IPcService
    {
        private readonly GamespyContext _context;
        private readonly IMapper _mapper;


        public PcService(GamespyContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task AddPc(Pc pc)
        {
            await _context.Pcs.AddAsync(pc);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePc(int id)
        {
            var pc = await _context.Pcs.FirstOrDefaultAsync(p => p.Pcid == id);

            try {

                if (pc == null)
                    throw new Exception("This pc is not registered in Database!!!");

                _context.Pcs.Remove(pc);
                await _context.SaveChangesAsync();

            }catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<Pc>> GetAllPcs()
        {
            var pcs = _context.Pcs.ToListAsync();

            return pcs;
        }

        public async Task<Pc> GetPcById(int id)
        {
            var pc = await _context.Pcs.FirstOrDefaultAsync(p => p.Pcid == id);

            try
            {
                if (pc == null)
                    throw new Exception("This PC is not registered in Database!!!");

                return pc;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdatePc(int id, Pc newPc)
        {
            var pc = await _context.Pcs.FirstOrDefaultAsync(p =>p.Pcid == id);

            try {

                if (pc == null)
                    throw new Exception("This PC is not registered in Database!!!");

                _mapper.Map<Pc, Pc>(newPc, pc);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
