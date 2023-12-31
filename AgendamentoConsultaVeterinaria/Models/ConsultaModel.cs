using AgendamentoConsultaVeterinaria.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendamentoConsultaVeterinaria.Models
{
    public class ConsultaModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataConsulta { get; set; }

        public TimeSpan HoraConsulta { get; set; }
        public StatusConsultaEnum StatusConsulta { get; set; }

        [ForeignKey("Unidade")]
        public int UnidadeId { get; set; }
        public UnidadeModel Unidade { get; set; }

        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public AnimalModel Animal { get; set; }

        [ForeignKey("Medico")]
        public int MedicoId { get; set; }
        public MedicoModel Medico { get; set; }
    }
}
