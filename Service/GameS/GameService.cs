using AutoMapper;
using GameSpy.DTOs;
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

        public async Task<List<GameDTO>> GetUsersGames(string userId)
        {
            List<GameDTO> userGames = new List<GameDTO>();
            List<UsersGames> userGameList = new List<UsersGames>();

            var allEntrys = await _context.UsersGames.ToListAsync();

            foreach (var entry in allEntrys)
            {
                if(entry.Userid == userId)
                    userGameList.Add(entry);
            }

            var games = GetAllGames();
            var mappedGames = new List<GameDTO>();


            foreach (Game game in await games)
            {
                foreach (var entry in userGameList)
                {
                    if (game.Gameid == entry.Gameid)
                    {
                        try
                        {
                            var mappedGame = new GameDTO();
                            mappedGame = _mapper.Map<Game, GameDTO>(game);
                            mappedGame.RecentTime = entry.RecentTime;
                            userGames.Add(mappedGame);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            return userGames;
        }

        public async Task<ICollection<Achievement>> GetUsersIngameAchievement(string userId, int id)
        {
            List<UsersAchievements> usersAchievementsDB = await _context.UsersAchievements.ToListAsync();
            List<UsersAchievements> usersAchievements = new List<UsersAchievements>();

            List<Achievement> achievementsDB = await _context.Achievements.ToListAsync();
            ICollection<Achievement> usersIngameAchievements = new List<Achievement>();

            
            foreach (UsersAchievements user in usersAchievementsDB)
            {
                if (user.Userid == userId)
                {
                    usersAchievements.Add(user);
                }
            }

            foreach (UsersAchievements achievements in usersAchievements)
            {
                foreach (Achievement achhievementDB in achievementsDB)
                {
                    if (achievements.Achievementid == achhievementDB.Achievementsid && achhievementDB.Gameid == id)
                    {
                        usersIngameAchievements.Add(achhievementDB);
                    }
                }
            }

            return usersIngameAchievements;
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

        public async Task UpdateRecentTime(int id)
        {
            var game = await _context.UsersGames.FirstOrDefaultAsync(g => g.Gameid == id);

            try
            {
                if (game == null)
                    throw new Exception("This Game is not registered in Database!!!");

                game.RecentTime = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
