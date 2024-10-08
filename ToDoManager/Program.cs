
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ToDoManager.Extensions;

namespace ToDoManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var logger = builder.Host.UseSerilog((context, loggerConfig) =>
                loggerConfig.ReadFrom.Configuration(context.Configuration));

            // Add services to the container.
            builder.Services.ConfigureCors();
            builder.Services.ConfigurePostgresConnection(builder.Configuration);
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServices();
            builder.Services.ConfigureActionFilters();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJwt(builder.Configuration);
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(ToDoManager.Presentation.AssemblyReference).Assembly);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.ConfigureSwagger();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(opt => { });

            app.UseSerilogRequestLogging();

            app.UseCors("CorsPoslicy");

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
