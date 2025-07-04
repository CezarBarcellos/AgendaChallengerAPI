using Data.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Data.Models
{
    [Table("Compromisso")]
    public class Compromisso : Entity
    {
        public required string Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public required DateTime DataInicio { get; set; }
        public required DateTime DataFim { get; set; }
        public string? Localizacao { get; set; }
        public required int Status { get; set; }

        public Compromisso() { }

        [SetsRequiredMembers]
        public Compromisso(string id, string titulo, string descricao, DateTime dataInicio, DateTime dataFim, string localizacao, int status)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Localizacao = localizacao;
            Status = status;
        }
    }
}
