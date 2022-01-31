using Microsoft.EntityFrameworkCore;
using WebCollection.Models;
namespace WebCollection.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<CollectionField> CollectionFields { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
    }
}
