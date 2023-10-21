using ApiForo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForo.Data;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {
        
    }
    //agregar entidades
    public DbSet<Comentario> Comentario { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>()
            .HasMany(c => c.Hijos)
            .WithOne(c => c.ComentarioPadre)
            .HasForeignKey(c => c.ComentarioPadreId);
    }
}