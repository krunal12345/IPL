using IPL.Entities;
using IPL.Models;

namespace IPL.Data.Contract
{
    public interface ITeamPayerRepository
    {
        public Task AddTeamAsync(Team team);
        public Task<List<Team>> GetTeamsAsync(bool addPlayers, string name = null);
        public Task<Team> GetTeamByIdAsync(int id);
        public Task<Player?> AddPlayerAsync(Player player);
        public Task<Player> GetPlayerByIdAsync(int Id);
        public Task<List<Player>> GetPlayersAsync(string name = null);
    }
}
