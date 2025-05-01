using AutoMapper;
using IPL.Entities;
using IPL.Models;

namespace IPL.AutoMappers
{
    public class TeamPlayerProfile: Profile
    {
        public TeamPlayerProfile() {
            CreateMap<Player, PlayerDTO>();
            CreateMap<PlayerDTO, Player>();
            CreateMap<Team, TeamDTO>();
            CreateMap<TeamDTO, Team>();
        }
    }
}
