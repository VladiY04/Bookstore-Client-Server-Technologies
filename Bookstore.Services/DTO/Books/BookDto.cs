using Bookstore.Services.DTO.Authors;
using Bookstore.Services.DTO.Genres;
using Bookstore.Services.DTO.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Services.DTO.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] CoverImage { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int? PublishingYear { get; set; }
        public decimal? Price { get; set; }
        public LanguageDto Language { get; set; }
        public ICollection<AuthorDto> Authors { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
    }
}
