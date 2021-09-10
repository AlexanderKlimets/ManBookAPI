using DataBaseRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManBookAPI.Services
{
    /// <summary>
    /// Интерфейс, предоставляющий необходимый функционал для работы с набором сущностей "Авторы".
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Получить всех авторов.
        /// </summary>
        /// <returns>Перечисление сущностей "Автор".</returns>
        public IEnumerable<Author> GetAllAuthors();

        /// <summary>
        /// Получить авторов, удовлетворяющих набору условий "pattern".
        /// </summary>
        /// <param name="pattern">Набор условий для фильтрации.</param>
        /// <returns>Перечисление отфильтрованных сущностей "Автор".</returns>
        public IEnumerable<Author> GetAuthorsBy(Func<Author, bool> pattern);

        /// <summary>
        /// Получить автора из DbSet Authors.
        /// </summary>
        /// <param name="author">Сущность автор.</param>
        /// <returns>Сущность "Автор" из DbSet</returns>
        public Author GetAuthor(Author author);

        /// <summary>
        /// Получить автора, удовлетворяющего набору условий "pattern".
        /// </summary>
        /// <param name="pattern">Набор условий для фильтрации.</param>
        /// <returns>Сущность "Автор".</returns>
        public Author GetAuthorBy(Func<Author, bool> pattern);

        /// <summary>
        /// Добавить сущность "Автор".
        /// </summary>
        /// <param name="author">Сущность "Автор".</param>
        public void AddAuthor(Author author);       

        /// <summary>
        /// Удалить сущность "Автор".
        /// </summary>
        /// <param name="author">Сущность "Автор".</param>
        public void DeleteAuthor(Author author);

        /// <summary>
        /// Удалить авторов, удовлетворяющих набору условий "pattern".
        /// </summary>
        /// <param name="pattern">Сущность "Автор".</param>
        public void DeleteAuthorBy(Func<Author, bool> pattern);

        /// <summary>
        /// Проверить, содержит ли набор сущностей "Авторы" сущность "Автор".
        /// </summary>
        /// <param name="author">Сущность "Автор".</param>
        /// <returns>True, если содержит и false, если нет.</returns>
        public bool Contains(Author author);

        /// <summary>
        /// Проверить, содержит ли набор сущностей "Авторы" сущность "Автор", удовлетворяющих набору условий "pattern".
        /// </summary>
        /// <param name="pattern">Набор условий для фильтрации.</param>
        /// <returns>True, если содержит и false, если нет.</returns>
        public bool ContainsBy(Func<Author, bool> pattern);
        
        /// <summary>
        /// Сохранить произошедшие изменения.
        /// </summary>
        public void Save();
        
    }
}
