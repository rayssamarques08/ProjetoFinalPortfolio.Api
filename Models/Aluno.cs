using System.Text.Json.Serialization;

namespace ProjetoFinalPortfolio.Api.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }
        public string Sobre_Aluno { get; set; }
        public string Atuacao { get; set; }
        public string Tecnologias { get; set; }
        public string Habilidades { get; set; }
        public string Ferramentas { get; set; }
        public string TurmaId { get; set; }

        [JsonIgnore]
        public Turma? Turmas { get; set; }

    }
}
