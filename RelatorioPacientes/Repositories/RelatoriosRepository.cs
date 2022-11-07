using Microsoft.EntityFrameworkCore;
using RelatorioPacientes.Model;

namespace RelatorioPacientes.Repositories
{
    public class RelatoriosRepository : IRelatoriosRepository
    {
        public readonly RelatoriosContext _context;

        public RelatoriosRepository(RelatoriosContext context)
        {
            _context = context;
        }
        public async Task<Relatorios> Create(Relatorios relatorio)
        {
            _context.Relatorio.Add(relatorio);
            await _context.SaveChangesAsync();

            return relatorio;
        }

        public async Task Delete(int id)
        {
            var relatorioToDelete = await _context.Relatorio.FindAsync(id);
            _context.Relatorio.Remove(relatorioToDelete);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Relatorios>> Get()
        {
            return await _context.Relatorio.ToListAsync();
        }

        public async Task<Relatorios> Get(int id)
        {
            return await _context.Relatorio.FindAsync(id);
        }

        public async Task Update(Relatorios relatorio)
        {
            _context.Entry(relatorio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
