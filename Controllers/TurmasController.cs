using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalPortfolio.Api.Data;
using ProjetoFinalPortfolio.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ProjetoFinalPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TurmasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            return await _context.Turmas.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarTurmas(Turma turma)
        {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();
            return Ok("Cadastro de turma realizado!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarTurma(int id, Turma turma)
        {
            var turmaAtual = await _context.Turmas.FindAsync(id);
            if (turmaAtual == null)
            {
                return NotFound();
            }
            turmaAtual.Nome = turma.Nome;
            turmaAtual.Periodo = turma.Periodo;
            turmaAtual.Professor = turma.Professor;

            await _context.SaveChangesAsync();

            return Ok("Turma alterada com sucesso!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeletarTurmas(int Id)
        {
            var turma = await _context.Turmas.FindAsync(Id);
            if (
                turma == null)
            {
                return NotFound();

            }
            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
