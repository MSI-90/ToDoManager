using Microsoft.EntityFrameworkCore;
using Persistence;

namespace ToDoManager.Extensions;

public static class ServiceExtensions
{
    public static void ConfigurePostgresConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(configuration.GetConnectionString("sqlConnection")));
    }
}
