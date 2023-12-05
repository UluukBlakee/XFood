using XFood.API.Configuration.Application;
using XFood.Data;

namespace XFood.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var corsPolicy = "_xFoodWebCors";
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
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}