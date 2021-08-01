using DataBaseRepository.DTO_s;
using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace DataBaseRepository
{
    /// <summary>
    /// Абстрактный класс, предоставляющий наборы для работы с сущностями базы данных и функции перевода моделей базы данных в DTO-объекты.
    /// </summary>
    public abstract class BasicContext : DbContext
    {
        /// <summary>
        /// Набор для работы с сущностью "Человек".
        /// </summary>
        public DbSet<Man> Men { get; set; }
        /// <summary>
        /// Набор для работы с сущностью "Книга".
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// Набор для работы с сущностью "Человек взял книгу".
        /// </summary>
        public DbSet<ManTakeBook> MenTakeBooks { get; set; }


        /// <summary>
        /// Позволяет преобразовать список сущностей "Человек" в набор DTO-объектов "Человек".
        /// </summary>
        /// <param name="manList">Список сущностей "Человек".</param>
        /// <returns>Набор DTO-объектов "Человек".</returns>
        protected IEnumerable<ManDto> ConvertManListToManDtoList(List<Man> manList)
        {
            var menDtoList = from man in manList
                             select new ManDto()
                             {
                                 Name = man.Name,
                                 Surname = man.Surname,
                                 Patronymic = man.Patronymic,
                                 BirthDate = man.BirthDate
                             };
            return menDtoList;
        }

        /// <summary>
        /// Позволяет преобразовать DTO-объект "Человек" в сущность "Человек".
        /// </summary>
        /// <param name="man">DTO-объект "Человек".</param>
        /// <returns>сущность "Человек".</returns>
        protected Man ConvertManDtoToMan(ManDto man)
        {
            return new Man()
            {
                Name = man.Name,
                Surname = man.Surname,
                Patronymic = man.Patronymic,
                BirthDate = man.BirthDate
            };
        }

        /// <summary>
        /// Позволяет преобразовать список сущностей "Книга" в набор DTO-объектов "Книга".
        /// </summary>
        /// <param name="bookList">Список сущностей "Книга".</param>
        /// <returns>Набор DTO-объектов "Книга".</returns>
        protected IEnumerable<BookDto> ConvertBookListToBookDtoList(List<Book> bookList)
        {
            var bookDtoList = from book in bookList
                              select new BookDto()
                              {
                                  Title = book.Title,
                                  AuthorName = book.AuthorName,
                                  Genre = book.Genre

                              };
            return bookDtoList;
        }

        /// <summary>
        /// Позволяет преобразовать DTO-объект "Книга" в сущность "Книга".
        /// </summary>
        /// <param name="book">DTO-объект "Книга".</param>
        /// <returns>Сущность "Книга".</returns>
        protected Book ConvertBookDtoToBook(BookDto book)
        {
            return new Book()
            {
                Title = book.Title,
                AuthorName = book.AuthorName,
                Genre = book.Genre
            };
        }

        /// <summary>
        /// Добавляет DTO-объект "Человек" в набор сущностей "Люди".
        /// </summary>
        /// <param name="man">DTO-объект "Человек".</param>
        public void AddMan(ManDto man)
        {
            var manToAdd = ConvertManDtoToMan(man);
            Men.Add(manToAdd);
            SaveChanges();
            
        }

        /// <summary>
        /// Добавляет DTO-объект "Книга" в набор сущностей "Книги".
        /// </summary>
        /// <param name="man">DTO-объект "Книга".</param>
        public void AddBook(BookDto book)
        {
            var bookToAdd = ConvertBookDtoToBook(book);
            Books.Add(bookToAdd);
            SaveChanges();
        }
    }
}
