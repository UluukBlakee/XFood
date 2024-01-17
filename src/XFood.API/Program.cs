using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using xFood.Infrastructure;
using XFood.API.Configuration.Application;
using XFood.Data;
using XFood.Data.Configuration;
using XFood.Data.Models;

namespace XFood.API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var corsPolicy = "_xFoodWebCors";
            IConfigurationSection jWTSettingsSection = builder.Configuration.GetSection(nameof(JWTSettings));
            builder.Services.Configure<JWTSettings>(jWTSettingsSection);
            var jWtOptions = new JWTSettings();
            builder.Configuration.GetSection(nameof(JWTSettings)).Bind(jWtOptions);


            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: corsPolicy,
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()   
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            builder.Services.RegisterDataServices(builder.Configuration)
                .ConfigureApplication();
            builder.Services.AddControllers();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jWtOptions.JwtIssuer,
                ValidAudience = jWtOptions.JwtAudience,
                IssuerSigningKey = jWtOptions.JwtSecurityKey
            };

            builder.Services.AddSingleton(tokenValidationParameters);
            
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParameters;
                });
            builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen();
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                 await Adminitializer.SeedAdminUser(roleManager, userManager);
                 
            }
            //await Pizzeriainitializer.SeedPizzeria(app.Services);
            app.UseCors(corsPolicy);
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}