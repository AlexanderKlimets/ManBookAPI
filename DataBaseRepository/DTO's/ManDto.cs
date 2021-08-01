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
    /// Класс, представляющий человека.
    /// </summary>
    public class ManDto
    {
        /// <summary>
        /// Имя человека.
        /// </summary>
        [Required]
        [JsonInclude]
        public string Name { get; set; }
        /// <summary>
        /// Фамилия человека.
        /// </summary>
        [Required]
        [JsonInclude]
        public string Surname { get; set; }
        /// <summary>
        /// Отчество человека.
        /// </summary>
        [Required]
        [JsonInclude]
        public string Patronymic { get; set; }
        /// <summary>
        /// Дата рождения человека.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-ddTHH:mm:ss.fffzzz}", ApplyFormatInEditMode = true)]
        public DateTimeOffset BirthDate { get; set; }
    }
}
