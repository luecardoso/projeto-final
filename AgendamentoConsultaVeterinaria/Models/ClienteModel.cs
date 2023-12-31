using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendamentoConsultaVeterinaria.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        //[EmailAddress]
        public string Email { get; set; }

        [ForeignKey("Endereco")]
        public int? EnderecoId { get; set; }
        public EnderecoModel? Endereco { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<AnimalModel> Animais { get; set; }
    }
}
