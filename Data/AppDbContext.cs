using Microsoft.EntityFrameworkCore;
using ProjetoFinalPortfolio.Api.Models;
namespace ProjetoFinalPortfolio.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
    }
}
