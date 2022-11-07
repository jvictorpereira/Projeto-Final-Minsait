using Microsoft.EntityFrameworkCore;

namespace RelatorioPacientes.Model
{
    public class RelatoriosContext : DbContext
    {
        public RelatoriosContext(DbContextOptions<RelatoriosContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Relatorios> Relatorio { get; set; }
    }
}
