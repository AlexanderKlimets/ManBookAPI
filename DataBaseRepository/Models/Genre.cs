using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseRepository.Models
{
    /// <summary>
    /// Класс представляющий собой модель сущности "Жанр".
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Идентификатор жанра.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название жанра.
        /// </summary>
        public string GenreName { get; set; }
        /// <summary>
        /// Список книг определенного жанра.
        /// </summary>
        public List<Book> GenreBooks { get; set; }

        public Genre()
        {
            GenreBooks = new List<Book>();
        }
    }
}
