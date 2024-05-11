using Microsoft.EntityFrameworkCore;
using AstralParserBack.Modules;

namespace AstralParserBack.DataContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<developer> developers { get; set; }
        public DbSet<admin> admins { get; set; }
        public DbSet<history> history { get; set; }
        public DbSet<job> jobs { get; set; }
        public DbSet<status> statuses { get; set; }
    }
}