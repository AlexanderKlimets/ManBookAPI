using DataBaseRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRepository.Interfaces
{
    public interface IBasicContext
    {
        DbSet<Man> Men { get; set; }
        
        DbSet<Book> Books { get; set; }
      
        DbSet<Author> Authors { get; set; }

        DbSet<Genre> Genres { get; set; }
        
        int SaveChanges();
    }
}
