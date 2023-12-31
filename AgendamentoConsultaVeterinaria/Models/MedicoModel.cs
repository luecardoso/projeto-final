using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendamentoConsultaVeterinaria.Models
{
    public class MedicoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Crmv { get; set; }
        //public List<TipoAnimalEnum> PetsQueAceita { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("Unidade")]
        public int UnidadeId { get; set; }
        public UnidadeModel Unidade { get; set; }

        public virtual ICollection<ConsultaModel> Consultas { get; set; }
    }
}
