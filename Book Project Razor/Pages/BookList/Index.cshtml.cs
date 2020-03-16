using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Project_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Book_Project_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        // Dostęp do bazy danych z naszego modelu
        private readonly ApplicationDbContext _db;
        // Konstruktor
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        // Pobierz dane z bazy danych
        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        // Kasowanie 
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Books.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}