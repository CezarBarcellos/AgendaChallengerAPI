using Data.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Data.Models
{
    [Table("Usuario")]
    public class Usuario : Entity
    {        
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }

        [SetsRequiredMembers]
        public Usuario(string nome, string email, string senha, bool ativo)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = ativo;
            DataCriacao = DateTime.UtcNow;
        }
    }
}
