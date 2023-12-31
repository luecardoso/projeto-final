using AgendamentoConsultaVeterinaria.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendamentoConsultaVeterinaria.Models
{
    public class AnimalModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoAnimalEnum TipoAnimal { get; set; }
        //[StringLength(50)]
        public string Raca { get; set; }
        //[StringLength(9)]
        public string Sexo { get; set; }
        //[DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
        //public int Idade { set; get; }
        public Decimal Peso { get; set; }
        public bool Castrado { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }
        public virtual ICollection<ConsultaModel> Consultas { get; set; }
    }
}
