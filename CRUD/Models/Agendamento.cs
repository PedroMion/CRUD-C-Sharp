namespace CRUD.Models 
{
    public class Agendamento 
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? Observacoes { get; set; }

        public string? Telefone { get; set; }

        public DateTime DataAgendamento { get; set; }

    }

}
