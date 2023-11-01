using System.ComponentModel.DataAnnotations;

namespace WebApp000002.Models
{
    public class ConsultaModel : paciente
    {
        public int IdConsulta { get; set; }
        public int IdPaciente { get; set; }
        public string DataConsulta { get; set; }
        public string NomeMedico { get; set; }
        public string FichaMedica { get; set; }

        public List<paciente> ListaPacientes { get; set; }
    }
}
