using Microsoft.AspNetCore.Mvc;
using Task1.Models;
using Microsoft.EntityFrameworkCore;

namespace Task1.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Books books)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(books);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Books books)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(books);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
