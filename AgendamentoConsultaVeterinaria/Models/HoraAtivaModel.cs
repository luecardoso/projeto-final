namespace AgendamentoConsultaVeterinaria.Models
{
    public class HoraAtivaModel
    {
        public int Id { get; set; }
        public string Hora { get; set; }
        public bool Ativa { get; set; }
        public int DataHoraId { get; set; }
        public DataHoraModel DataHora { get; set; }
    }
}
