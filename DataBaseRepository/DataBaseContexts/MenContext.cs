using DataBaseRepository.DTO_s;
using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseRepository.DataBaseContexts
{
    public class MenContext : BasicContext
    {
        /// <summary>
        /// Класс, позволяющий работать с набором сущностей "Люди".
        /// </summary>
        public MenContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=mandb;Trusted_Connection=True;");
        }


        /// <summary>
        /// Позволяет получить набор DTO-объектов, представляющих все сущности набора "Люди".
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ManDto> GetAllMen()
        {
            var menList = Men.ToList();
            return ConvertManListToManDtoList(menList);
        }

        /// <summary>
        /// Позволяет получить набор DTO-объектов, представляющих все сущности набора "Люди" с заданным именем.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        /// <returns>Набор DTO-объектов "Люди".</returns>
        public IEnumerable<ManDto> GetMenByName(string name)
        {
            var manList = Men.Where(x => x.Name == name).ToList();
            return ConvertManListToManDtoList(manList);
        }

        /// <summary>
        /// Позволяет получить новый список DTO-объектов "Человек" с добавленным объектом. 
        /// </summary>
        /// <param name="man">DTO-объект "Человек".</param>
        /// <returns>Новый список DTO-объектов "Человек".</returns>
        public IEnumerable<ManDto> AddManAndReturnList(ManDto man)
        {
            AddMan(man);          
            return ConvertManListToManDtoList(Men.ToList());
        }

        /// <summary>
        ///  Позволяет удалить сущность "Человек" по заданному имени, отчеству и фамилии.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        /// <param name="surname">Фамилия человека.</param>
        /// <param name="patronymic">Отчество человека.</param>
        public void DeleteMan(string name, string surname, string patronymic)
        {
            var menToDelete = Men.Where(x => x.Name == name && x.Surname == surname && x.Patronymic == patronymic).ToList();

                Men.RemoveRange(menToDelete);
                SaveChanges();          
        }
    }
}
