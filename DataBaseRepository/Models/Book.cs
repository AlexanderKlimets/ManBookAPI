using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Author Author { get; set; }
        /// <summary>
        /// Жанр книги.
        /// </summary>
        //[ForeignKey("Genre_test")]
        public List<Genre> Genres { get; set; }

        public List<Man> BookMen { get; set; }

        public Book()
        {
            Author = new Author();
            Genres = new List<Genre>();
            BookMen = new List<Man>();
        }
    }
}
