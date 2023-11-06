using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp000002.Models
{
    public class Consulta 
    {

        [Key]
        public int IdConsulta { get; set; }
        public int IdPaciente { get; set; }
        public string DataConsulta { get; set; }
        public string NomeMedico { get; set; }
        public string FichaMedica { get; set; }

       public string Paciente { get; set; }
       

      
    }
} 
