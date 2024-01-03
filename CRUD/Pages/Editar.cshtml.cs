using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Pages {

    public class EditarModel : PageModel
    {
        private readonly ILogger<EditarModel> _logger;
        private readonly agendamentoContext _context;

        [BindProperty]
        public Agendamento? AgendamentoEditado { get; set; } = default!;

        public EditarModel(ILogger<EditarModel> logger, agendamentoContext context)
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

            AgendamentoEditado = agend;

            return Page();
        }

        public IActionResult OnPost() 
        {
            if(AgendamentoEditado != null) 
            {
                try {
                    _context.Entry(AgendamentoEditado).State = EntityState.Modified;
                    _context.SaveChanges();
                } catch(Exception e) {
                    Console.WriteLine(e.StackTrace);
                    return NotFound();
                }
            }

            return RedirectToPage("Visualizar");
        }
    }
}
