using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using xFood.Infrastructure;
using XFood.API.Configuration.Application;
using XFood.Data;
using XFood.Data.Models;

namespace XFood.API
{
    public class Program
    {
        public static void Main(string[] args)
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

            builder.Services.AddControllers();

            builder.Services.RegisterDataServices(builder.Configuration)
                .ConfigureApplication();


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