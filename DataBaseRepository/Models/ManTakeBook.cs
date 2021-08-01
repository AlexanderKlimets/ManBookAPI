using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataBaseRepository.Models
{
    /// <summary>
    /// Класс, представляющий собой модель сущности "Человек берет книгу".
    /// </summary>
    public class ManTakeBook
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Человек, взявший книгу.
        /// </summary>
        public Man Man { get; set; }
        /// <summary>
        /// Книга, взятая человеком.
        /// </summary>
        public Book Book { get; set; }
        /// <summary>
        /// Время, когда книга была взята человеком.
        /// </summary>
        public DateTimeOffset TakingTime { get; set; }
    }
}
