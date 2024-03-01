using AutoMapper;
using GameSpy.Models;

namespace GameSpy.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, User>();
            CreateMap<Pc, Pc>();
            CreateMap<Game, Game>();
        }
    }
}
