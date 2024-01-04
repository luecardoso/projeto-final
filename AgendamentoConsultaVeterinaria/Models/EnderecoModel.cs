using System.ComponentModel.DataAnnotations;

namespace AgendamentoConsultaVeterinaria.Models
{
    public class EnderecoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
    }
}
