using System.Text.Json.Serialization;

namespace ProjetoFinalPortfolio.Api.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Titulo_Projeto { get; set; }
        public string Descricao_Projeto { get; set; }
        public string Link { get; set; }
        public string Imagem_Video { get; set; }
        public int AlunoId { get; set; }

        [JsonIgnore]
        public Aluno? Aluno { get; set; }
    }
}
