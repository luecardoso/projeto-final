using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendamentoConsultaVeterinaria.Models
{
    public class AnimalModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        public string TipoAnimal { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
        public Double Peso { get; set; }
        public bool Castrado { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }
        public virtual ICollection<ConsultaModel> Consultas { get; set; }

        public AnimalModel()
        {
            //TipoAnimal = new List<string>()
            //{
            //    "Cachorro",
            //    "Coelho",
            //    "Furão",
            //    "Gato",
            //    "Hamster",
            //    "Pássaro",
            //    "Porquinho da India"
            //};
        }
    }
}
