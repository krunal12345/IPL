using IPL.Data;
using IPL.Data.Contract;
using IPL.Data.Repository;
using IPL.Service;
using IPL.Service.Contract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

namespace IPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<IPLDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("IPLConnectionString")));

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWt:SecretKey"]!)),
                    ValidateAudience = true,
                    ValidAudience = config["JWt:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = config["JWt:Issuer"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            #region DI
            builder.Services
                .AddTransient<ITeamPayerRepository, TeamPayerRepository>()
                .AddTransient<ITeamPlayerService, TeamPlayerService>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IUserService, UserService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Configure Swagger BEFORE UseSwaggerUI
                app.UseSwagger(options =>
                {
                    options.RouteTemplate = "/openapi/{documentName}.json";
                });

                app.UseSwaggerUI();

                // Map Scalar API reference - this will be available at /scalar/v1
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("IPL API Documentation")
                           .WithTheme(ScalarTheme.BluePlanet)
                           .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}