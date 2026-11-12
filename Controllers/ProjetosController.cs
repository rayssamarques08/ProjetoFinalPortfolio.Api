using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalPortfolio.Api.Data;
using ProjetoFinalPortfolio.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFinalPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjetosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetAgendamentos()
        {
            return await _context.Projetos.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> FazerAgendamento(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
            return Ok("Projeto cadastrado!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarProjeto(int id, Projeto projeto)
        {
            var projetoAtual = await _context.Projetos.FindAsync(id);
            if (projetoAtual == null)
            {
                return NotFound();
            }
            projetoAtual.Titulo_Projeto = projeto.Titulo_Projeto;
            projetoAtual.Descricao_Projeto = projeto.Descricao_Projeto;
            projetoAtual.Link = projeto.Link;
            projetoAtual.Imagem_Video = projeto.Imagem_Video;

            await _context.SaveChangesAsync();

            return Ok("Projeto alterado com sucesso!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarProjetos(int Id)
        {
            var projeto = await _context.Projetos.FindAsync(Id);
            if (
                projeto == null)
            {
                return NotFound();

            }
            _context.Projetos.Remove(projeto );
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
