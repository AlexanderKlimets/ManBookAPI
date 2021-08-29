using DataBaseRepository;
using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManBookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BasicContext _context;

        public BookService(DbContextOptions<BasicContext> options)
        {
            _context = new BasicContext(options);
        }

        public void AddBook(Book book) =>

            _context.Books.Add(book);
        

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
