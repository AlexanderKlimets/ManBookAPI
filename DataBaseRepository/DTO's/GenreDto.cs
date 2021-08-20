using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseRepository.DTO_s
{
    /// <summary>
    /// Класс, представляющий жанр.
    /// </summary>
    public class GenreDto
    {
        /// <summary>
        /// Название жанра.
        /// </summary>
        public string GenreName { get; set; }

        /// <summary>
        /// Список книг определенного жанра.
        /// </summary>
        public List<BookDto> GenreBooks { get; set; }
    }
}
