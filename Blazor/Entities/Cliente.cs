using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BlazorClientes.Shared.Entities
{
    public class Cliente { 
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public int Idade { get; set; }
    }
}
