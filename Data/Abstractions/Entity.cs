using System.ComponentModel.DataAnnotations;

namespace Data.Abstractions
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; init; }
        public required bool Ativo { get; set; }
        public required DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        protected Entity(int id) { Id = id; }
        protected Entity() {  }       
    }
}
