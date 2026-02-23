using GameOfLive.Lib.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace GameOfLive.Lib.DB.Business
{
    public class DatabaseContext : DbContext
    {
        public DbSet<SimulationFrame> SimulationFrames { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }
    }
}
