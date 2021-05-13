using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Reflection;

namespace Selly.NMS.Web.Models
{
    public class MainDbContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<PacketDroppedEvent> Events { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyRule> PolicyRules { get; set; }

        public MainDbContext() { }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Here for the benefit of the API project which does not register the dbcontext as a service.
            // TODO: Move all database logic to a dedicated project so that it can be shared between NMS and API.
            string dbPath = Environment.GetEnvironmentVariable("DATABASE_PATH");

            if (dbPath == null)
            {
                string asmPath = Assembly.GetExecutingAssembly().Location;
                string asmParent = Path.GetDirectoryName(asmPath);
                dbPath = Path.Combine(asmParent, "selly.db");
            }

            string db = $@"Data Source={dbPath};";

            optionsBuilder.UseSqlite(db);
        }
    }
}
