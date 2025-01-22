using ComicCollectorApp.Model.Comics;
using Microsoft.EntityFrameworkCore;

namespace ComicCollectorApp.Model
{
    public class ComicCollectorDbContext : DbContext
    { 
        //public DbSet<Comic> Comics { get; set; }

        //public DbSet<Author> Authors { get; set; }

        //public DbSet<Publisher> Publishers { get; set; }

        //public DbSet<Language> Languages { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=ComicCollector.db");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Comic>()
        //        .HasOne(c => c.Author)
        //        .WithMany(a => a.Comics)
        //        .HasForeignKey(c => c.Author.Id);

        //    modelBuilder.Entity<Comic>()
        //        .HasOne(c => c.Publisher)
        //        .WithMany(p => p.Comics)
        //        .HasForeignKey(c => c.Publisher.Id);

        //    modelBuilder.Entity<Comic>()
        //        .HasOne(c => c.Language)
        //        .WithMany(l => l.Comics)
        //        .HasForeignKey(c => c.Language.Id);

        //    modelBuilder.Entity<Comic>()
        //        .HasDiscriminator<TypeComic>("ComicType")
        //        .HasValue<Comic>(TypeComic.TPB)
        //        .HasValue<ComicSingle>(TypeComic.Single);
        //}
    }
}
