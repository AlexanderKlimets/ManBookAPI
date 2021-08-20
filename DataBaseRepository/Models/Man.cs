using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseRepository.Models
{
    /// <summary>
    /// Класс, представляющий собой модель сущности "Человек".
    /// </summary>
    public class Man
    {
        /// <summary>
        /// Идентификатор человека.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя человека.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия человека.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Отчество человека.
        /// </summary>
        public string Patronymic { get; set; }  
        /// <summary>
        /// Дата рождения человека.
        /// </summary>
        public DateTimeOffset BirthDate { get; set; }

        /// <summary>
        /// Список книг человека.
        /// </summary>
        public List<Book> ManBooks { get; set; }

        public Man()
        {
            ManBooks = new List<Book>();
        }
    }
}
