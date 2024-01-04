using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendamentoConsultaVeterinaria.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }
        [EmailAddress(ErrorMessage = "Adicione um email válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Senha { get; set; }
        [ForeignKey("Endereco")]
        public int? EnderecoId { get; set; }
        public EnderecoModel? Endereco { get; set; }
        public virtual ICollection<AnimalModel> Animais { get; set; }
    }
}
