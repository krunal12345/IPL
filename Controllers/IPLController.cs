using IPL.Models;
using IPL.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IPLController : ControllerBase
    {
        private readonly ITeamPlayerService _teamPlayerService;
        public IPLController(ITeamPlayerService teamPlayerService)
        {
            this._teamPlayerService = teamPlayerService;
        }

        #region Get
        [HttpGet]
        [Route("teams")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TeamDTO>>> GetAllTeamsAsync(bool addPlayers, 
            string name = null)
        {
            var teams = await _teamPlayerService.GetTeamsAsync(addPlayers, name);
            return Ok(teams);
        }


        [HttpGet]
        [Route("teams/{id}")]
        [Authorize]
        public async Task<ActionResult<TeamDTO>> GetTeamByIdAsync(int id)
        {
            var team = await _teamPlayerService.GetTeamAsync(id);
            if (team == null)
                return NotFound();

            return Ok(team);
        }

        [HttpGet]
        [Route("players")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> GetAllPlayersAsync(string name = null)
        {
            var teams = await _teamPlayerService.GetPlayersAsync(name);
            return Ok(teams);
        }

        [HttpGet]
        [Route("players/{id}")]
        public async Task<ActionResult<PlayerDTO>> GetPlayerByIdAsync(int id)
        {
            var player = await _teamPlayerService.GetPlayerByIdAsync(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        #endregion

        #region put/post
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("teams")]
        public async Task<IActionResult> CreateTeamAsync(TeamDTO team)
        {
            try
            {
                await this._teamPlayerService.AddTeamAsync(team);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("players")]
        public async Task<ActionResult<PlayerDTO>> CreatePlayerAsync(PlayerDTO player)
        {
            try
            {
                await this._teamPlayerService.AddPlayerAsync(player);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
