using Microsoft.EntityFrameworkCore;
using Pointage.Infrastructure.Entities;

namespace Pointage.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<StudentEntity> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("Data Source=presence.db");
}