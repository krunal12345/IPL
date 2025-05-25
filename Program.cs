
using IPL.Data;
using IPL.Data.Contract;
using IPL.Data.Repository;
using IPL.Service;
using IPL.Service.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Scalar.AspNetCore;

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

            #region DI
            builder.Services
                .AddTransient<ConfigurationManager>()
                .AddTransient<ITeamPayerRepository, TeamPayerRepository>()
                .AddTransient<ITeamPlayerService, TeamPlayerService>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IUserService, UserService>();
            #endregion

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
