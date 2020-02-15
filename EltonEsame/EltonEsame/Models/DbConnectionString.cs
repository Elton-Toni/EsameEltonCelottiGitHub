namespace EltonEsame.Models
{
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class DbConnectionString : DbContext
  {
    public DbConnectionString()
        : base("name=DbConnectionString")
    {
    }

    public virtual DbSet<Registry> Registries { get; set; }
    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Registry>()
          .HasMany(e => e.Tickets)
          .WithOptional(e => e.Registry)
          .HasForeignKey(e => e.InternaPersonId);

      modelBuilder.Entity<Registry>()
          .HasMany(e => e.Tickets1)
          .WithOptional(e => e.Registry1)
          .HasForeignKey(e => e.RegistryId);
    }
  }
}
