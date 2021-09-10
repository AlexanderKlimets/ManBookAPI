using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using DataBaseRepository.Interfaces;

namespace DataBaseRepository
{
    /// <summary>
    /// Абстрактный класс, предоставляющий наборы для работы с сущностями базы данных и функции перевода моделей базы данных в DTO-объекты.
    /// </summary>
    public class BasicContext : DbContext, IBasicContext
    {
        //public DbSet<Library> Library { get; set; }
        /// <summary>
        /// Набор для работы с сущностью "Человек".
        /// </summary>
        public DbSet<Man> Men { get; set; }
        /// <summary>
        /// Набор для работы с сущностью "Книга".
        /// </summary>
        public DbSet<Book> Books { get; set; }
        
        /// <summary>
        /// Набор для работы с сущьностью "Авторы".
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Набор для работы с сущностью "Жанры".
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        public BasicContext(DbContextOptions<BasicContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Man>()
            .ToTable("Men").HasKey(m => m.Id);           
            modelBuilder.Entity<Book>()
                .ToTable("Books").HasKey(b => b.Id);            
            modelBuilder.Entity<Author>()
                    .ToTable("Authors").HasKey(a => a.Id);
            modelBuilder.Entity<Genre>()
                    .ToTable("Genres").HasKey(m => m.Id);

            modelBuilder.Entity<Man>().HasData(new Man[]
            {
                new Man 
                {                    
                    Id = 1,                         
                    Name = "Tom",                         
                    Surname = "Mavrin",                         
                    Patronymic = "Ivanovich",                        
                    BirthDate = DateTimeOffset.Now,                            
                    ManBooks = new List<Book>()
                },
                new Man
                {
                    Id = 2,
                    Name = "Jerry",
                    Surname = "Boil",
                    Patronymic = "Semenovich",
                    BirthDate = DateTimeOffset.Now,
                    ManBooks = new List<Book>()
                },
                new Man
                {
                    Id = 3,
                    Name = "Affen",
                    Surname = "Sunset",
                    Patronymic = "Sergeyevich",
                    BirthDate = DateTimeOffset.Now,
                    ManBooks = new List<Book>()
                }
            });

            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre
                {
                    Id = 1,
                    GenreName = "novel",
                    GenreBooks = new List<Book>()
                },
                new Genre
                {
                    Id = 2,
                    GenreName = "historical",
                    GenreBooks = new List<Book>()
                },
                new Genre
                {
                    Id = 3,
                    GenreName = "fantasy",
                    GenreBooks = new List<Book>()
                }
            }
            );

            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author
                {
                    Id = 1,
                    FirstName = "Alexey",
                    LastName = "Pehov",
                    MiddleName = "Ivanovich"
                },
                new Author
                {
                    Id = 2, 
                    FirstName = "Roman", 
                    LastName = "Prokofev", 
                    MiddleName = "Olegovich"
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Oleg",
                    LastName = "Terentev",
                    MiddleName = "Igorevich"
                }
            });          
        }
    }
}
