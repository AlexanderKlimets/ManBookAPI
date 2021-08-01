using DataBaseRepository.DTO_s;
using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseRepository.DataBaseContexts
{
    /// <summary>
    /// Класс, позволяющий работать с набором сущностей "Люди берут книги".
    /// </summary>
    public class ManTakeBookContext : BasicContext
    {

        public ManTakeBookContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=mantakebookdb;Trusted_Connection=True;");
        }

        /// <summary>
        /// Позволяет преобразовать список сущностей "Человек берет книгу" в набор DTO-объектов "Человек берет книгу".
        /// </summary>
        /// <param name="menTakeBooks">Список сущностей "Человек берет книгу".</param>
        /// <returns>Новый список DTO-объектов "Человек берет книгу".</returns>
        private IEnumerable<ManTakeBookDto> ConvertManTakeBookListToManTakeBookDtoList(List<ManTakeBook> menTakeBooks)
        {
            var menTakeBooksDtoList = new List<ManTakeBookDto>();

            Men.ToList();
            Books.ToList();
            BookDto bookToAdd;
            foreach (var manTakeBook in menTakeBooks)
            {
                var manToAdd = new ManDto()
                {
                    Name = manTakeBook.Man.Name,
                    Surname = manTakeBook.Man.Surname,
                    Patronymic = manTakeBook.Man.Patronymic,
                    BirthDate = manTakeBook.Man.BirthDate
                };
            
                bookToAdd = new BookDto()
                {
                    Title = manTakeBook.Book.Title,
                    AuthorName = manTakeBook.Book.AuthorName,
                    Genre = manTakeBook.Book.Genre
                };
                menTakeBooksDtoList.Add(new ManTakeBookDto() { Man = manToAdd, Book = bookToAdd, TakingTime = manTakeBook.TakingTime });
            }

            return menTakeBooksDtoList;
        }

        /// <summary>
        /// Позволяет получить набор DTO-объектов, представляющих все сущности набора "Люди берут книги".
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ManTakeBookDto> GetAllManTakeBook()
        {
            var menTakeBooksList = MenTakeBooks.ToList();
            var menList = Men.ToList();
            var bookToList = Books.ToList();
            return ConvertManTakeBookListToManTakeBookDtoList(menTakeBooksList);
        }

        /// <summary>
        /// Позволяет получить новый список DTO-объектов "Человек берет книгу" с добавленным объектом.
        /// </summary>
        /// <param name="newMenTakeBooks">DTO-объект "Человек берет книгу".</param>
        /// <returns>Новый список DTO-объектов "Человек берет книгу".</returns>
        public IEnumerable<ManTakeBookDto> AddManTakeBook(ManTakeBookDto newMenTakeBooks)
        {
            AddMan(newMenTakeBooks.Man);
            AddBook(newMenTakeBooks.Book);
            var newMenTakeBooksToAdd = new ManTakeBook
            {
                Man = ConvertManDtoToMan(newMenTakeBooks.Man),
                Book = ConvertBookDtoToBook(newMenTakeBooks.Book),
                TakingTime = newMenTakeBooks.TakingTime
            };
            var myTest = MenTakeBooks.ToList();
            MenTakeBooks.Attach(newMenTakeBooksToAdd);
            SaveChanges();
            return ConvertManTakeBookListToManTakeBookDtoList(MenTakeBooks.ToList());
        }
    }
}
