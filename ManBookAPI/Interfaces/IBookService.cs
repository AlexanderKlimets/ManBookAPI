using DataBaseRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManBookAPI.Services
{
    /// <summary>
    /// Интерфейс, предоставляющий необходимый функционал для работы с набором сущностей "Книги".
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Получить все книги.
        /// </summary>
        /// <returns>Перечисление сущностей "Книга".</returns>
        public IEnumerable<Book> GetAllBooks();
        /// <summary>
        /// Получить книги, удовлетворяющих набору условий "pattern".
        /// </summary>
        /// <param name="pattern">Набор условий для фильтрации.</param>
        /// <returns>Перечисление отфильтрованных сущностей "Книги".</returns>
        public IEnumerable<Book> GetBooksBy(Func<Book, bool> pattern);
        /// <summary>
        /// Добавть сущность "Книга".
        /// </summary>
        /// <param name="book">Новая сущность "Книга".</param>
        public void AddBook(Book book);
        /// <summary>
        /// Удалить книгу.
        /// </summary>
        /// <param name="authorName">Имя автора книги.</param>
        /// <param name="title">Название книги.</param>
        public void DeleteBooks(Author authorName, string title);        
        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        public void Save();
        /// <summary>
        /// Получить автора из DbSet Authors.
        /// </summary>
        /// <param name="book">Сущность "Книга".</param>
        /// <returns>Сущность "Книга" из DbSet</returns>       
        public Book GetBook(Book book);
        /// <summary>
        /// Поолучить книгу, удовлетворяющую условию pattern.
        /// </summary>
        /// <param name="pattern">Условие фильтрации.</param>
        /// <returns>Сущность "Книга", удовлетворяющая условию.</returns>
        public Book GetBookBy(Func<Book, bool> pattern);
        /// <summary>
        /// Получить книгу по ее id.
        /// </summary>
        /// <param name="book">id книги.</param>
        /// <returns></returns>
        public Book GetBookById(int book);
        /// <summary>
        /// Определить, содержится ли данные экземпляр сущности "Книга".
        /// </summary>
        /// <param name="book">Сущность "Книга".</param>
        /// <returns>True, если содержится, иначе false.</returns>
        public bool Contains(Book book);
        /// <summary>
        /// Определить, содержится ли экземпляр сущности "Книга", удовлетворяющий условию фитрации pattern/
        /// </summary>
        /// <param name="pattern">Условие фильтрации.</param>
        /// <returns>True, если содержится, иначе false.</returns>
        public bool ContainsBy(Func<Book, bool> pattern);
    }
}
