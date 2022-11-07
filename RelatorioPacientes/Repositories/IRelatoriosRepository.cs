using RelatorioPacientes.Model;

namespace RelatorioPacientes.Repositories
{
    public interface IRelatoriosRepository
    {
        Task<IEnumerable<Relatorios>> Get();

        Task<Relatorios> Get(int id);

        Task<Relatorios> Create(Relatorios relatorio);

        Task Update(Relatorios relatorio);

        Task Delete(int id);
    }
}
