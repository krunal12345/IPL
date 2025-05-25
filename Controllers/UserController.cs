using IPL.Models;
using IPL.Service.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : Controller
    {

        [HttpPost("Add")]
        public async Task<IActionResult> AddUser(UserDTO user)
        {
            await userService.AddUser(user);
            return NoContent();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Tokens>> LoginUser(LoginUser user)
        {
            try
            {
                Tokens? tokens = await userService.LoginUser(user);
                if (tokens == null)
                {
                    return BadRequest("User does not exist");
                }
                return Ok(tokens);
            }
            catch (Exception ex)
            {
                return BadRequest("UserName or passWord not correct");
            }
        }
    }
}
