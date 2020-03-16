using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Project_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_Project_Razor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        // Dostęp do bazy danych z naszego modelu
        private readonly ApplicationDbContext _db;
        // Konstruktor
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // Dzięki temu ten obiekt będzie dostępny w metodzie OnPost
        [BindProperty]
        public Book Book { get; set; }

        // Pobierz dane z bazy danych
        public void OnGet()
        {
             
        }

        // Sprawdź dane przed dodaniem
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                // Jeśli dane są okey dodaj je do obiektu
                await _db.Books.AddAsync(Book);
                // Dodaj dane do bazy obiekt
                await _db.SaveChangesAsync();
                // Wróc do strony Index 
                return RedirectToPage("Index");

            }
            else
            {
                return Page();
            }
        }
    }
}