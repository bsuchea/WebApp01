using Microsoft.EntityFrameworkCore;
using WebApp01.Models.Entites;

namespace WebApp01.Models{

    public class MysqlContext: DbContext {

        public MysqlContext(DbContextOptions<MysqlContext> options) : base (options) {}

        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }

    }
}