using DataBaseRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManBookAPI.Services
{
    /// <summary>
    /// Интерфейс, предоставляющий необходимый функционал для работы с набором сущностей "Люди".
    /// </summary>
    public interface IManService
    {
        /// <summary>
        /// Получить всех людей.
        /// </summary>
        /// <returns>Перечисление сущностей "Человек".</returns>
        public IEnumerable<Man> GetAllMen();

        /// <summary>
        /// Получить людей, удовлетворяющих набору условий "pattern".
        /// </summary>
        /// <param name="pattern">Набор условий для фильтрации.</param>
        /// <returns>Перечисление отфильтрованных сущностей "Человек".</returns>
        public IEnumerable<Man> GetMenBy(Func<Man, bool> pattern);
        
        /// <summary>
        /// Получить человека из DbSet Men.
        /// </summary>
        /// <param name="man">Сущность человек.</param>
        /// <returns>Сущность "Человек" из DbSet.</returns>
        public Man GetMan(Man man);

        /// <summary>
        /// Получить человека, удовлетворяющего условию pattern.
        /// </summary>
        /// <param name="pattern">Условие фильтрации.</param>
        /// <returns>Сущность "Человек", удовлетворяющая условию.</returns>
        public Man GetManBy(Func<Man, bool> pattern);
        
        /// <summary>
        /// Добавить человека.
        /// </summary>
        /// <param name="man">Новый человек.</param>
        public void AddMan(Man man);

        /// <summary>
        /// Изменить существующего человека.
        /// </summary>
        /// <param name="man">Новый человек.</param>
        public void UpdateMan(Man man);

        /// <summary>
        /// Удалить человека.
        /// </summary>
        /// <param name="man">Сущность "Человек".</param>
        public void DeleteMan(Man man);
        
        /// <summary>
        /// Удалить человека, удовлетворяющего условию pattern.
        /// </summary>
        /// <param name="pattern">Условие фильтрации.</param>
        public void DeleteMenBy(Func<Man, bool> pattern);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="man"></param>
        /// <returns></returns>
        public bool Contains(Man man);
        public bool ContainsBy(Func<Man, bool> pattern);
        
        /// <summary>
        /// Получить список книг человека.
        /// </summary>
        /// <param name="id">id человека.</param>
        /// <returns>Список книг человека.</returns>
        public List<Book> GetManBooks(int id);

        /// <summary>
        /// Добавить книгу человеку.
        /// </summary>
        /// <param name="man">Сущность "Человек".</param>
        /// <param name="book">Сущность "Книга".</param>
        public void AddManBook(Man man, Book book);

        /// <summary>
        /// Удалить книгу у человека.
        /// </summary>
        /// <param name="man">Сущность "Человек".</param>
        /// <param name="book">Сущность "Книга".</param>
        public void DeleteManBook(Man man, Book book);

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        public void Save();

    }
}
