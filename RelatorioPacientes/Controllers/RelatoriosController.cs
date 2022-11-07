using Microsoft.AspNetCore.Mvc;
using RelatorioPacientes.Model;
using RelatorioPacientes.Repositories;
using System.Threading.Tasks;

namespace RelatorioPacientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatoriosRepository _relatoriosRepository;
        public RelatoriosController(IRelatoriosRepository relatoriosRepository)
        {
            _relatoriosRepository = relatoriosRepository;

        }
        [HttpGet]
        public async Task<IEnumerable<Relatorios>> GetRelatorios()
        {
            return await _relatoriosRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Relatorios>> GetRelatorios( int id)
        {
            return await _relatoriosRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Relatorios>> PostRelatorios([FromBody] Relatorios relatorios)
        {
            var newRelatorio = _relatoriosRepository.Create(relatorios);
            return CreatedAtAction(nameof(GetRelatorios), new { id = newRelatorio.Id }, newRelatorio);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var relatoriosToDelete = await _relatoriosRepository.Get(id);
            
            if(relatoriosToDelete == null)
                return NotFound();
            
            await _relatoriosRepository.Delete(relatoriosToDelete.Id);
            return NoContent();

        }
        [HttpPut]
        public async Task<ActionResult> PutRelatorios(int id, [FromBody] Relatorios relatorios)
        {
            if (id == relatorios.Id)
                return BadRequest();
            
            await _relatoriosRepository.Update(relatorios);
            return NoContent();

            
        }


    }
}
