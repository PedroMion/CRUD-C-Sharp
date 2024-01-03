using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages {

    public class VisualizarModel : PageModel
    {
        private readonly ILogger<VisualizarModel> _logger;

        private readonly agendamentoContext _context;

        public List<Agendamento>? ListaAgendamentos { get; set; } = new List<Agendamento>();

        public VisualizarModel(ILogger<VisualizarModel> logger, agendamentoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            ListaAgendamentos = _context.Agendamentos.ToList();
        }

        public void Deletar(int id)
        {
            Console.WriteLine("Teste");
        }
    }
}