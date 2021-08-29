using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseRepository.DTO_s
{
    /// <summary>
    /// Класс, представляющий автора.
    /// </summary>
    public class AuthorDto
    {
        /// <summary>
        /// Имя автора.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия автора.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество автора.
        /// </summary>
        public string MiddleName { get; set; }
    }
}
