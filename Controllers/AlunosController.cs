using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalPortfolio.Api.Data;
using ProjetoFinalPortfolio.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFinalPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync(); 
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarAlunos(Aluno alunos)
        {
            _context.Alunos.Add(alunos);
            await _context.SaveChangesAsync();
            return Ok("Cadastro de aluno realizado!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarAluno(int id, Aluno aluno)
        {
            var alunoAtual = await _context.Alunos.FindAsync(id);
            if (alunoAtual == null)
            {
                return NotFound();
            }
            alunoAtual.Nome = aluno.Nome;
            alunoAtual.Turma = aluno.Turma;
            alunoAtual.Sobre_Aluno = aluno.Sobre_Aluno;
            alunoAtual.Atuacao = aluno.Atuacao;
            alunoAtual.Tecnologias = aluno.Tecnologias;
            alunoAtual.Habilidades = aluno.Habilidades;
            alunoAtual.Ferramentas = aluno.Ferramentas;

            await _context.SaveChangesAsync();

            return Ok("Aluno alterado com sucesso!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeletarAlunos(int Id)
        {
            var aluno = await _context.Alunos.FindAsync(Id);
            if (
                aluno == null)
            {
                return NotFound();

            }
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
