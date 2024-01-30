using Finshark.Models;
using Microsoft.EntityFrameworkCore;

namespace Finshark.ApplicationDBContextF
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) {  }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
