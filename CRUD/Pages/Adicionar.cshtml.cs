using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD.Models;

namespace CRUD.Pages {

    public class AdicionarModel : PageModel
    {
        private readonly ILogger<AdicionarModel> _logger;
        private readonly agendamentoContext _context;

        [BindProperty]
        public Agendamento? novoAgendamento { get; set; }

        public AdicionarModel(ILogger<AdicionarModel> logger, agendamentoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost() 
        {
            if(novoAgendamento != null) 
            {
                _context.Agendamentos.Add(novoAgendamento);

                _context.SaveChanges();
            }

            return RedirectToPage("Visualizar");
        }
    }
}
