using Data.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Usuario")]
    public class Usuario : Entity
    {        
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
