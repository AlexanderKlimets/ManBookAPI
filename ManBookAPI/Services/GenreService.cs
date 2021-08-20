using DataBaseRepository;
using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManBookAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly BasicContext _context;

        public GenreService(DbContextOptions<BasicContext> options)
        {
            _context = new BasicContext(options);
        }

        public IEnumerable<Genre> GetAllGenres() =>
            
            _context.Genres.Include(g => g.GenreBooks);


        public IEnumerable<Genre> GetGenresBy(Func<Genre, bool> pattern) =>
           
            _context.Genres.Where(pattern);


        public Genre GetGenreBy(Func<Genre, bool> pattern) =>
            
            _context.Genres.SingleOrDefault(pattern);


        public void AddGenre(Genre genre) =>
            
            _context.Genres.Add(genre);        


        public void UpdateGenre(Genre genre)
        {
            var genreToUpdate = GetGenreBy(g => g.Id == genre.Id);
            _context.Entry(genreToUpdate).State = EntityState.Modified;
            genreToUpdate.GenreName = genre.GenreName;
        }


        public void DeleteGenre(Genre genre) =>
            
            _context.Genres.RemoveRange(genre);


        public void DeleteGenreBy(Func<Genre, bool> pattern) =>
           
            _context.Genres.RemoveRange(GetGenresBy(pattern));
        

        public bool Contains(Genre genre) =>
            
            _context.Genres.Any(g => g.GenreName == genre.GenreName);


        public bool ContainsBy(Func<Genre, bool> pattern) =>
            
            _context.Genres.Any(pattern);


        public Dictionary<string, int> GetStatistic() =>
           
            _context.Genres
               .GroupBy(d => d.GenreName)
               .Select(d => new { name = d.Key, count = d.Count() })
               .ToDictionary(g => g.name, c => c.count);


        public void Save() =>
            
            _context.SaveChanges();
    }
}
