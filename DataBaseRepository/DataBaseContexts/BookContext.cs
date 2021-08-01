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
    /// Класс, позволяющий работать с набором сущностей "Книги".
    /// </summary>
    public class BookContext : BasicContext
    {

        public BookContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bookdb;Trusted_Connection=True;");
        }       

        /// <summary>
        /// Позволяет получить набор DTO-объектов, представляющих все сущности набора "Книги".
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookDto> GetAllBooks()
        {
            var booksList = Books.ToList();
            return ConvertBookListToBookDtoList(booksList);
        }

        /// <summary>
        /// Позволяет получить набор DTO-объектов, представляющих все сущности набора "Книги" с заданным именем автора.
        /// </summary>
        /// <param name="authorName">Имя автора.</param>
        /// <returns>Набор DTO-объектов "Книги".</returns>
        public IEnumerable<BookDto> GetBooksByAuthorName(string authorName)
        {
            var bookList = Books.Where(x => x.AuthorName == authorName).ToList();
            return ConvertBookListToBookDtoList(bookList);

        }

        /// <summary>
        /// Позволяет получить новый список DTO-объектов "Книга" с добавленным объектом.
        /// </summary>
        /// <param name="book">DTO-объект "Книга".</param>
        /// <returns>Новый список DTO-объектов "Книга".</returns>
        public IEnumerable<BookDto> AddBookAndReturnList(BookDto book)
        {
            AddBook(book);           
            return ConvertBookListToBookDtoList(Books.ToList());
        }

        /// <summary>
        /// Позволяет удалить сущность "Книга" по заданному названию и имени автора.
        /// </summary>
        /// <param name="authorName">Имя автора книги.</param>
        /// <param name="title">Название книги.</param>
        public void DeleteBook(string authorName, string title)
        {
            var booksToDelete = Books.Where(x => x.AuthorName == authorName && x.Title == title).ToList();
            Books.RemoveRange(booksToDelete);
            SaveChanges();
        }

    }
}
