using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RuculaX.EntityFramework;

public static class PostgressService
{
    public static void ConfigureServices(this IServiceCollection services, string stringConnection)
    {
        services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(stringConnection));
    }
}
