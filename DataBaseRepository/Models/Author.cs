using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseRepository.Models
{
    /// <summary>
    /// Класс представляющий собой модель сущности "Автор".
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int Id { get; set; }
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

        public override bool Equals(object obj)
        {
            var author = obj as Author;
            if(author == null)
            {
                return false;
            }
            var expOne = Id == author.Id &&
                FirstName == author.FirstName &&
                LastName == author.LastName;
            var expTwo = Id == author.Id &&
                FirstName == author.FirstName &&
                MiddleName == author.MiddleName;
            var expThree = Id == author.Id &&
                LastName == author.LastName &&
                MiddleName == author.MiddleName;
            var expFour = FirstName == author.FirstName &&
                LastName == author.LastName &&
                MiddleName == author.MiddleName;
            return expOne || expTwo || expThree || expFour;
        }
    }
}
