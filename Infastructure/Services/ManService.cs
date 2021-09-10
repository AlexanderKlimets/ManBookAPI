using DataBaseRepository;
using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManBookAPI.Services
{
    /// <summary>
    /// Интерфейс, предоставляющий необходимый функционал для работы с набором сущностей "Люди".
    /// </summary>
    public class ManService : IManService
    {
        private readonly BasicContext _context;

        public ManService(DbContextOptions<BasicContext> options)
        {
            _context = new BasicContext(options);
        }


        public void AddMan(Man man) =>

            _context.Men.Add(man);


        public void DeleteMan(string name) =>

            _context.Men.RemoveRange(GetMenBy(m => m.Name == name));


        public void DeleteMenBy(Func<Man, bool> pattern) =>

            _context.Men.RemoveRange(GetMenBy(pattern));


        public IEnumerable<Man> GetAllMen() =>
            
            _context.Men;           
        

        public IEnumerable<Man> GetMenBy(Func<Man, bool> pattern) =>

            _context.Men.Where(pattern);


        public void Save() =>
            
            _context.SaveChanges();


        public Man GetManById(int id) =>

            _context.Men.Find(id);


        public bool Contains(Man man) =>
            
            _context.Men.Any(m => m.Name == man.Name && m.Surname == man.Surname && m.Patronymic == man.Patronymic);


        public bool ContainsBy(Func<Man, bool> pattern) =>
            
            _context.Men.Any(pattern);


        public List<Book> GetManBooks(int id) =>
            
            _context.Men.Single(m => m.Id == id).ManBooks;


        public void AddManBook(Man man, Book book) =>
           
            man.ManBooks.Add(book);


        public Man GetMan(Man man) =>
            
            _context.Men.SingleOrDefault(m => m.Id == man.Id);


        public Man GetManBy(Func<Man, bool> pattern) =>
            _context.Men.SingleOrDefault(pattern);


        public void DeleteMan(Man man) =>
            _context.Men.RemoveRange(GetMan(man));

        public void DeleteManBook(Man man, Book book) =>
            man.ManBooks.Remove(book);


        public void UpdateMan(Man man)
        {
            var manToUpdate = GetManBy(m => m.Id == man.Id);
            _context.Entry(manToUpdate).State = EntityState.Modified;
            manToUpdate.Name = man.Name;
            manToUpdate.Surname = man.Surname;
            manToUpdate.Patronymic = man.Patronymic;
            manToUpdate.BirthDate = man.BirthDate;
        }   
    }
}
