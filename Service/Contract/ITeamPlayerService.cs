using IPL.Entities;
using IPL.Models;

namespace IPL.Service.Contract
{
    public interface ITeamPlayerService
    {
        public Task AddTeamAsync(TeamDTO teamDto);
        public Task<TeamDTO> GetTeamAsync(int id);
        public Task<List<TeamDTO>> GetTeamsAsync(bool addPlayers, string name = null);
        public Task<PlayerDTO?> AddPlayerAsync(PlayerDTO player);
        public Task<PlayerDTO> GetPlayerByIdAsync(int Id);
        public Task<List<PlayerDTO>> GetPlayersAsync(string name = null);
    }
}
