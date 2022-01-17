using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess
{
    public class ICtegoryRepository : DbContext
    {
        public ICtegoryRepository(DbContextOptions<ICtegoryRepository> Options) : base(Options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }

        internal DbSet<object> DbSet()
        {
            throw new NotImplementedException();
        }
    }
}
