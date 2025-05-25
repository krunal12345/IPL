using AutoMapper;
using IPL.Data.Contract;
using IPL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace IPL.Data.Repository
{
    public class TeamPayerRepository: ITeamPayerRepository
    {
        private readonly IPLDbContext _iplDbContext;
        public TeamPayerRepository(IPLDbContext dbContext) { 
            this._iplDbContext = dbContext;
        }

        public async Task AddTeamAsync(Team team)
        {
            await this._iplDbContext.Teams.AddAsync(team);

            await _iplDbContext.SaveChangesAsync();
        }

        public async Task<List<Team>> GetTeamsAsync(bool addPlayers, string name = null)
        {
            var teamsQuery = _iplDbContext.Teams
                .Where(team => string.IsNullOrEmpty(name) ||
                    team.Name.ToLower().Contains(name.ToLower()) ||
                    team.FancyName.ToLower().Contains(name.ToLower()));
            if (addPlayers)
            {
                teamsQuery = teamsQuery.Include(team => team.Players);
            }

            return teamsQuery.ToList();
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await _iplDbContext.Teams.FindAsync(id);
        }

        public async Task<Player?> AddPlayerAsync(Player player)
        {
            await this._iplDbContext.Players.AddAsync(player);
            await this._iplDbContext.SaveChangesAsync();
            return await this.GetPlayerByIdAsync(player.Id);
        }

        public async Task<Player> GetPlayerByIdAsync(int Id)
        {
            return await this._iplDbContext.Players.FindAsync(Id);
        }

        public async Task<List<Player>> GetPlayersAsync(string name = null)
        {
            return await this._iplDbContext.Players
                .Where(p => String.IsNullOrEmpty(name) || 
                    p.Name.ToLower().Contains(name))
                .ToListAsync();
        }
    }
}
