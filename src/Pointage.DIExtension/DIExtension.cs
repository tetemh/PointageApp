using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pointage.Core.Dtos;
using Pointage.Core.IRepositories;
using Pointage.Infrastructure.Contexts;
using Pointage.Infrastructure.Repositories;

namespace Pointage.DIExtension;

public static class DIExtension
{
    public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>();

        services.AddTransient<IStudentRepository, StudentRepository>();
    }

    public static void ConfigDbContext(this IServiceCollection services, WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();
            if (!db.Students.Any())
            {
                db.Students.AddRange(
                new StudentDto { Name = "Alice Liddell", IsPresent = false },
                new StudentDto { Name = "Bob Marley", IsPresent = false },
                new StudentDto { Name = "Charlie Brown", IsPresent = false }
                );
                db.SaveChanges();
            }
        }
    }
}
