using AutoMapper;
using GameSpy.DTOs;
using GameSpy.Models;
using Humanizer;

namespace GameSpy.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser, UserDTO>();
            CreateMap<Game, GameDTO>();
            CreateMap<Game, Game>();
        }
    }
}
