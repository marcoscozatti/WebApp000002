

using System.ComponentModel.DataAnnotations;

namespace WebApp000002.Models
{
    public class paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }


    }
}
