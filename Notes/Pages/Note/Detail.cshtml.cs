using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Data;
using Notes.Services;

namespace Notes.Pages.Note;

public class DetailModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly NoteService _noteService;
    public Models.Note? Note { get; set; } = new();
    
    public DetailModel(ApplicationDbContext context)
    {
        _context = context;
        _noteService = new NoteService(_context);
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        Note = await _noteService.GetByIdAsync(id);

        if (Note == null)
            return NotFound();

        return Page();
    }
}