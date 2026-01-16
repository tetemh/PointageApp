using Microsoft.EntityFrameworkCore;
using Pointage.Core.Dtos;

namespace Pointage.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<StudentDto> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("Data Source=presence.db");
}