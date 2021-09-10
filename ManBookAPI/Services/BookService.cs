using DataBaseRepository;
using DataBaseRepository.DTO_s;
using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManBookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BasicContext _context;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;

        public BookService(DbContextOptions<BasicContext> options, 
                           IAuthorService authorService,
                           IGenreService genreService)
        {
            _context = new BasicContext(options);
            _authorService = authorService;
            _genreService = genreService;
        }

        


        public void AddBook(Book book)
        {
            //IAuthorService authorService;
            if(!_authorService.Contains(book.Author))
            //if(!_context.Authors.Contains(book.Author))
            {
                //_context.Authors.Add(book.Author);
                _authorService.AddAuthor(book.Author);
            }
            foreach(Genre genre in book.Genres)
            {
                //if(!_context.Genres.Contains(genre))
                if(!_genreService.Contains(genre))
                {
                    _genreService.AddGenre(genre);
                    //_context.Genres.Add(genre);
                }
            }
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        

        public void DeleteBooks(Author authorName, string title) =>

            _context.Books.RemoveRange(GetBooksBy(b => b.Author.FirstName == authorName.FirstName && b.Title == title));


        public IEnumerable<Book> GetAllBooks() =>

            _context.Books.Include(b => b.Author).Include(b => b.Genres);
        
        
        public IEnumerable<Book> GetBooksBy(Func<Book, bool> pattern) => 
            
            _context.Books.Where(pattern);


        public void Save() => 
            
            _context.SaveChanges();


        public Book GetBook(Book book) =>
            _context.Books.Find(book.Id);
       

        public Book GetBookById(int book) =>
            
            _context.Books.Find(book);


        public bool Contains(Book book) =>
            _context.Books.Any(b => b.Author.Equals(book.Author) && b.Title == book.Title);


        public bool ContainsBy(Func<Book, bool> pattern) =>
            _context.Books.Any(pattern);


        public Book GetBookBy(Func<Book, bool> pattern) =>
            _context.Books.SingleOrDefault(pattern);      
    }
}
