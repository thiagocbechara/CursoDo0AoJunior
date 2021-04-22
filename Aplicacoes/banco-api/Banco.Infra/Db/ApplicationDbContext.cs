using Banco.Domain.Database;
using Microsoft.EntityFrameworkCore;

namespace Banco.Infra.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<ContaEntity> Contas { get; set; }
    }
}
