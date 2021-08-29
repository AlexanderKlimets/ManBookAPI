using DataBaseRepository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataBaseRepository.DTO_s
{
    /// <summary>
    /// Класс, представляющий книгу.
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Название книги.
        /// </summary>
        [Required]
        [JsonInclude]
        public string Title { get; set; }
        /// <summary>
        /// Имя автора книги.
        /// </summary>
        [Required]
        [JsonInclude]
        public AuthorDto Author { get; set; }
        /// <summary>
        /// Жанр книги.
        /// </summary>
        [Required]
        public List<GenreDto> Genres { get; set; }
    }
}
