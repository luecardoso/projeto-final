namespace AgendamentoConsultaVeterinaria.Models
{
    public class DataHoraModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public List<HoraAtivaModel> HorasAtivas { get; set; }

        public DataHoraModel() 
        {
            horas();
        }

        private List<HoraAtivaModel> horas()
        {
            List<HoraAtivaModel> horas = new List<HoraAtivaModel>();
            for (int i=0; i< 24; i++)
            {
                horas.Add(new HoraAtivaModel { Hora = "0"+i+":00", Ativa = true });
            }
            return horas;
        }
    }
}
