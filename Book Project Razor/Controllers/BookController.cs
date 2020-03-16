using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Project_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Project_Razor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        // Dostęp do bazy danych z naszego modelu
        private readonly ApplicationDbContext _db;
        // Konstruktor
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Pobieranie danych przez controller
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Books.ToListAsync() });
        }

        // Kasowanie danych
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb =await _db.Books.FirstOrDefaultAsync(u => u.Id == id);
            if(bookFromDb == null )
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Books.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}