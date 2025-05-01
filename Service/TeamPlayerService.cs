using AutoMapper;
using IPL.Data.Contract;
using IPL.Entities;
using IPL.Models;
using IPL.Service.Contract;

namespace IPL.Service
{
    public class TeamPlayerService : ITeamPlayerService
    {
        private readonly ITeamPayerRepository _teamPayerRepository;
        private readonly IMapper _mapper;

        public TeamPlayerService(ITeamPayerRepository teamPlayerRepository, IMapper mapper)
        {
            this._teamPayerRepository = teamPlayerRepository;
            this._mapper = mapper;
        }

        public async Task AddTeamAsync(TeamDTO teamDto)
        {
            var team = _mapper.Map<Team>(teamDto);

            await this._teamPayerRepository.AddTeamAsync(team);
        }

        public async Task<List<TeamDTO>> GetTeamsAsync(bool addPlayers, string name)
        {
            var teams = await _teamPayerRepository.GetTeamsAsync(addPlayers, name);
            return teams.Select(_mapper.Map<TeamDTO>).ToList();
        }

        public async Task<TeamDTO> GetTeamAsync(int id)
        {
            var team = await _teamPayerRepository.GetTeamByIdAsync(id);
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<PlayerDTO?> AddPlayerAsync(PlayerDTO player)
        {
            var team = await _teamPayerRepository.AddPlayerAsync(_mapper.Map<Player>(player));
            return _mapper.Map<PlayerDTO>(team);
        }

        public async Task<PlayerDTO> GetPlayerByIdAsync(int Id)
        {
            var player = await _teamPayerRepository.GetPlayerByIdAsync(Id);
            return _mapper.Map<PlayerDTO>(player);
        }

        public async Task<List<PlayerDTO>> GetPlayersAsync(string name = null)
        {
            var players = await _teamPayerRepository.GetPlayersAsync(name);
            return players.Select(_mapper.Map<PlayerDTO>).ToList();
        }
    }
}
