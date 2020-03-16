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
    public class UpsertModel : PageModel
    {
        // Dostęp do bazy danych z naszego modelu
        private readonly ApplicationDbContext _db;
        // Konstruktor
        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        // Dostaje id z przycisku Edit
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            if(id==null)
            {
                // Create
                return Page();
            }

            // Update
            Book =await _db.Books.FirstOrDefaultAsync(u => u.Id == id);
            if(Book==null)
            {
                return NotFound();
            }
            return Page();
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id ==0)
                {
                    _db.Books.Add(Book);
                }
                else
                {
                    _db.Books.Update(Book);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}