using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages {

    public class DeletarModel : PageModel
    {
        private readonly ILogger<DeletarModel> _logger;
        private readonly agendamentoContext _context;

        [BindProperty]
        public Agendamento? Agendamento { get; set; } = default!;

        public DeletarModel(ILogger<DeletarModel> logger, agendamentoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {   
            if(id == null) 
            {
                return NotFound();
            }

            var agend = _context.Agendamentos.FirstOrDefault(x => x.Id == id);

            if(agend == null) {
                return NotFound();
            }

            Agendamento = agend;

            return Page();
        }

        public IActionResult OnPost(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var agend = _context.Agendamentos.Find(id);

            if (agend != null)
            {
                Agendamento = agend;
                _context.Agendamentos.Remove(Agendamento);
                _context.SaveChanges();
            }

            return RedirectToPage("Visualizar");
        }
    }
}
