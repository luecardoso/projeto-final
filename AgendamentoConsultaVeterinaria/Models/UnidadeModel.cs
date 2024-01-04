using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendamentoConsultaVeterinaria.Models
{
    public class UnidadeModel
    {
        [Key]
        public int Id { get; set; }
        public int? HoraId { get; set; }
        public HoraAtivaModel? HorarioFuncionamento { get; set; }
        public string? Telefone { get; set; }
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public EnderecoModel Endereco { get; set; }
        public virtual ICollection<ConsultaModel> Consultas { get; set; }
    }
}
