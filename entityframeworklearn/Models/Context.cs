using Microsoft.EntityFrameworkCore;

namespace entityframeworklearn.Models;

public class Context : DbContext
{
    public DbSet<Article> article { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
        .Property<string>("idarticle")
        .HasDefaultValueSql("articlesequence.NEXTVAL");

        modelBuilder.Entity<Article>()
        .Property<string>("nomarticle");

        modelBuilder.Entity<Article>()
        .Property<double>("prix");

        
        modelBuilder.Entity<Article>()
        .Property<int>("etat");
        
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured){
            optionsBuilder.UseNpgsql("Host=localhost;Database=entity;Username=postgres;Password=0000;");
        }
    }
}
