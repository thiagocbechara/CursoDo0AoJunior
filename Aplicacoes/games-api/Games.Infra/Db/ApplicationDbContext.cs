using Games.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Games.Infra.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<GameResult> GameResults { get; set; }
    }
}
