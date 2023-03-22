using Bookstore.Entities;
using Bookstore.Services.DTO.Authors;
using Bookstore.Services.DTO.Books;
using Bookstore.Services.DTO.Genres;
using Bookstore.Services.DTO.Languages;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Web
{
    public class BooksService
    {
        private readonly Bookstore_v2023Context _dbContext;

        public BooksService(Bookstore_v2023Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BookDto>> GetAll()
        {
            var books = await _dbContext.Books
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Include(b => b.Language)
            .ToListAsync();
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                Price = b.Price,
                CoverImage = b.CoverImage,
                Publisher = b.Publisher,
                ISBN = b.Isbn,
                PublishingYear = b.PublishingYear,
                Language = new LanguageDto()
                {
                    Id = b.Language.Id,
                    Name = b.Language.Name
                },
                Authors = b.Authors.Select(ba => new AuthorDto
                {
                    Id = ba.Id,
                    FullName = $"{ba.FirstName} {ba.LastName}"
                }).ToList(),
                Genres = b.Genres.Select(bg => new GenreDto
                {
                    Id = bg.Id,
                    Name = bg.Name
                }).ToList()
            }).ToList();
        }
        public async Task<List<BookDto>> Search(string searchTerm)
        {
            var books = await _dbContext.Books
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Include(b => b.Language)
            .Where(b => b.Title.Contains(searchTerm))
            .ToListAsync();
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                Price = b.Price,
                CoverImage = b.CoverImage,
                Publisher = b.Publisher,
                ISBN = b.Isbn,
                PublishingYear = b.PublishingYear,
                Language = new LanguageDto()
                {
                    Id = b.Language.Id,
                    Name = b.Language.Name
                },
                Authors = b.Authors.Select(ba => new AuthorDto
                {
                    Id = ba.Id,
                    FullName = $"{ba.FirstName} {ba.LastName}"
                }).ToList(),
                Genres = b.Genres.Select(bg => new GenreDto
                {
                    Id = bg.Id,
                    Name = bg.Name
                }).ToList()
            }).ToList();
        }
        public async Task<BookDto> GetById(int bookId)
        {
            var book = await _dbContext.Books
            .Include(b => b.Authors)
            .Include(b => b.Genres)
            .Include(b => b.Language)
            .FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null)
            {
                return null;
            }
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                CoverImage = book.CoverImage,
                Publisher = book.Publisher,
                ISBN = book.Isbn,
                PublishingYear = book.PublishingYear,
                Language = new LanguageDto()
                {
                    Id = book.Language.Id,
                    Name = book.Language.Name
                },
                Authors = book.Authors.Select(ba => new AuthorDto
                {
                    Id = ba.Id,
                    FullName = $"{ba.FirstName} {ba.LastName}"
                }).ToList(),
                Genres = book.Genres.Select(bg => new GenreDto
                {
                    Id = bg.Id,
                    Name = bg.Name
                }).ToList()
            };
        }
    }
}

