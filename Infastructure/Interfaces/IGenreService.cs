using DataBaseRepository.Models;
using System;
using System.Collections.Generic;

namespace ManBookAPI.Services
{
    /// <summary>
    /// Интерфейс, предоставляющий необходимый функционал для работы с набором сущностей "Жанры".
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Получить все жанры.
        /// </summary>
        /// <returns>Перечисление сущностей "Жанр".</returns>
        public IEnumerable<Genre> GetAllGenres();
        
        /// <summary>
        /// Получить жанры, удовлетворяющих набору условий "pattern".
        /// </summary>
        /// <param name="pattern">Набор условий для фильтрации.</param>
        /// <returns>Перечисление отфильтрованных сущностей "Жанр".</returns>
        public IEnumerable<Genre> GetGenresBy(Func<Genre, bool> pattern);
        
        /// <summary>
        /// Получить жанр, удовлетворяющий условия фильтрации pattern.
        /// </summary>
        /// <param name="pattern">Условие фильтрации.</param>
        /// <returns>Сущность "Жанр", удовлетворяющая условию фильтрации.</returns>
        public Genre GetGenreBy(Func<Genre, bool> pattern); 
        
        /// <summary>
        /// Добавить жанр.
        /// </summary>
        /// <param name="genre">Сущность "Жанр".</param>
        public void AddGenre(Genre genre);
        
        /// <summary>
        /// Изменить существующий жанр.
        /// </summary>
        /// <param name="genre">Новая сущность "Жанр".</param>
        public void UpdateGenre(Genre genre);

        /// <summary>
        /// Удалить жанр.
        /// </summary>
        /// <param name="genre">Сущность "Жанр".</param>
        public void DeleteGenre(Genre genre);

        /// <summary>
        /// Удалить жанр, удовлетворяющий условию фильтрации pattern.
        /// </summary>
        /// <param name="pattern"></param>
        public void DeleteGenreBy(Func<Genre, bool> pattern);

        /// <summary>
        /// Определить, содержится ли данные экземпляр сущности "Жанр".
        /// </summary>
        /// <param name="genre">Сущность "Жанр".</param>
        /// <returns>True, если содержится, иначе false.</returns>
        public bool Contains(Genre genre);

        /// <summary>
        /// Определить, содержится ли экземпляр сущности "Жанр", удовлетворяющий условию фильтрации pattern.
        /// </summary>
        /// <param name="pattern">Условие фильтрации.</param>
        /// <returns>True, если содержится, иначе false.</returns>
        public bool ContainsBy(Func<Genre, bool> pattern);

        /// <summary>
        /// Получить статистику по количеству книг разных жанров.
        /// </summary>
        /// <returns>Словарь пар (жанр - количество книг)</returns>
        public Dictionary<string, int> GetStatistic();

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        public void Save();
       
    }
}
