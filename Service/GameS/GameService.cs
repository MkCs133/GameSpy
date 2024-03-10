using AutoMapper;
using GameSpy.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSpy.Service.GameS
{
    public class GameService : IGameService
    {
        private readonly GameSpyContext _context;
        private readonly IMapper _mapper;

        public GameService(GameSpyContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task AddGame(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGame(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Gameid == id);

            try
            {

                if (game == null)
                    throw new Exception("This Game is not registered in Database!!!");

                _context.Games.Remove(game);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Game>> GetAllGames()
        {
            var games = await _context.Games.ToListAsync();

            return games;
        }

        public async Task<Game> GetGameById(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Gameid == id);

            try
            {

                if (game == null)
                    throw new Exception("This Game is not registered in Database!!!");

                return game;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateGame(int id, Game newGame)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Gameid == id);

            try
            {

                if (game == null)
                    throw new Exception("This Game is not registered in Database!!!");

                _mapper.Map<Game, Game>(newGame, game);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
