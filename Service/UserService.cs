using IPL.Data.Contract;
using IPL.Entities;
using IPL.Models;
using IPL.Service.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IPL.Service
{
    public class UserService(IUserRepository userRepo, IConfiguration configuration) : IUserService
    {
        public async Task AddUser(UserDTO user)
        {
            var usr = new User()
            {
                Email = user.Email,
                Name = user.Name,
                Role = user.Role,
                HashPassword = new PasswordHasher<UserDTO>().HashPassword(user, user.Password)
            };
            await userRepo.AddUser(usr);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await userRepo.GetUserByEmail(email);
        }

        public async Task<Tokens?> LoginUser(LoginUser user)
        {
            User? userDetails = await this.GetUserByEmail(user.Email);
            if (userDetails == null)
            {
                return null;
            }

            // Create a UserDTO with the same data used during registration
            var userDto = new UserDTO
            {
                Email = userDetails.Email,
                Name = userDetails.Name,
                Role = userDetails.Role,
            };

            bool isPassWordCorrect = this.VerifyPassWord(userDto, user.Password, userDetails.HashPassword);
            if (!isPassWordCorrect)
            {
                throw new Exception("User Name or PassWord not correct");
            }

            return this.GenerateTokens(userDetails);
        }

        private bool VerifyPassWord(UserDTO user, string passWord, string storedPassword)
        {
            return new PasswordHasher<UserDTO>().VerifyHashedPassword(user, storedPassword, passWord)
                == PasswordVerificationResult.Success;
        }

        private Tokens GenerateTokens(User userDetails)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userDetails.Name),
                new Claim(ClaimTypes.Email, userDetails.Email),
                new Claim(ClaimTypes.Role, userDetails.Role)
            };

            try{
                byte[] key = Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]);
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
                SigningCredentials creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                string accessToken = new JwtSecurityTokenHandler().WriteToken(token);
                var tokens = new Tokens()
                {
                    AccessToken = accessToken
                };
                return tokens;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}