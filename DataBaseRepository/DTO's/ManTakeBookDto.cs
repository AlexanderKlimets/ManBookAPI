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
    /// Класс-агрегатор "Человек взял книгу".
    /// </summary>
    public class ManTakeBookDto
    {
        /// <summary>
        /// Класс, представляющий человека.
        /// </summary>
        [Required]
        [JsonInclude]
        public ManDto Man { get; set; }

        /// <summary>
        /// Класс, представляющий книгу.
        /// </summary>
        [Required]       
        public BookDto Book { get; set; }

        /// <summary>
        /// Время, когда книга была взята человеком.
        /// </summary>
        [Required]        
        [DisplayFormat(DataFormatString = "{yyyy-MM-ddTHH:mm:ss.fffzzz}", ApplyFormatInEditMode = true)]
        public DateTimeOffset TakingTime { get; set; }
    }
}
