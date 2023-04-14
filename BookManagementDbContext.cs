using BookManagement.Services.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BookManagement
{
    public class BookManagementDbContext : DbContext
    {
        public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
