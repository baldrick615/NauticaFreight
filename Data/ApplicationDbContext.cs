using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Models.Domain;

namespace NauticaFreight.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Port> Ports { get; set; }
    public DbSet<PortSchedule> PortSchedules { get; set; }
    public DbSet<Vessel> Vessels { get; set; }

    /*
    public DbSet<Invoice> Invoices { get; set; }
    
    public DbSet<Shipment> Shipments { get; set; }
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>()
            .Property(c => c.PaymentTerms)
            .HasConversion<string>();
    }
}

