using Bookstore.Services.DTO.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Web.Pages
{
    public class BookModel : PageModel
    {
        private readonly BooksService _booksService;
        public BookDto? Book { get; set; }
        public BookModel(BooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Book = await _booksService.GetById(id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}
