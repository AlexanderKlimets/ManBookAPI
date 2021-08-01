using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataBaseRepository.Models
{
    /// <summary>
    /// Класс представляющий собой модель сущности "Книга".
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Имя автора книги.
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// Жанр книги.
        /// </summary>
        public string Genre { get; set; }
    }
}
