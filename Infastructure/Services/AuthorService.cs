using DataBaseRepository;
using DataBaseRepository.Interfaces;
using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManBookAPI.Services
{
    public class AuthorService : IAuthorService
    {
        //private readonly BasicContext _context;
        private IBasicContext _context;

        //public AuthorService(DbContextOptions<BasicContext> options)
        //{
        //    _context = new BasicContext(options);
        //}

        public AuthorService(IBasicContext testContext)
        {
            this._context = testContext;
        }


        //private readonly IBasicContext _context;

        //public AuthorService(IBasicContext context)
        //{
        //    _context = (BasicContext)context;
        //}


        public void AddAuthor(Author author) =>
            _context.Authors.Add(author);


        public bool Contains(Author author) =>
            _context.Authors.Contains(author);


        public bool ContainsBy(Func<Author, bool> pattern) =>
            _context.Authors.Any(pattern);


        public void DeleteAuthor(Author author) =>
            _context.Authors.RemoveRange(GetAuthorBy(a => a.Id == author.Id));
        

        public void DeleteAuthorBy(Func<Author, bool> pattern) =>
            _context.Authors.RemoveRange(GetAuthorBy(pattern));
        

        public IEnumerable<Author> GetAllAuthors() =>
            _context.Authors;


        public Author GetAuthor(Author author) =>
            _context.Authors.SingleOrDefault(a => a.Id == author.Id);


        public Author GetAuthorBy(Func<Author, bool> pattern) =>
            _context.Authors.SingleOrDefault(pattern);
        

        public IEnumerable<Author> GetAuthorsBy(Func<Author, bool> pattern) =>
            _context.Authors.Where(pattern);
        

        public void Save() =>
            _context.SaveChanges();
    }
}
