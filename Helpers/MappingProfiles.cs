using AutoMapper;
using GameSpy.Models;
using Humanizer;

namespace GameSpy.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser, AppUser>();
            CreateMap<Game, Game>();
            CreateMap<Pc, Pc>();
        }
    }
}
