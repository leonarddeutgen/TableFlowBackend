using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Entities;

namespace WebApplication2.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<BillItem> BillItems { get; set; }
    
    public DbSet<BillItemLog> BillItemLogs { get; set; }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<PermissionModel> PermissionModels { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ===== Organisation (ALLT NoAction) =====
        modelBuilder.Entity<Organisation>()
            .HasMany(o => o.Rooms)
            .WithOne(r => r.Organisation)
            .HasForeignKey(r => r.OrganisationId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Organisation>()
            .HasMany(o => o.Categories)
            .WithOne(c => c.Organisation)
            .HasForeignKey(c => c.OrganisationId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Organisation>()
            .HasMany(o => o.Products)
            .WithOne()
            .HasForeignKey(p => p.OrganisationId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Organisations)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<User>()
            .HasOne(u => u.PermissionModel)
            .WithMany()
            .HasForeignKey(u => u.PermissionId)
            .OnDelete(DeleteBehavior.NoAction);


        // ===== SÄKRA cascade-kedjor =====

        modelBuilder.Entity<Room>()
            .HasMany(r => r.Tables)
            .WithOne(t => t.Room)
            .HasForeignKey(t => t.RoomId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Table>()
            .HasMany(t => t.Bills)
            .WithOne(b => b.Table)
            .HasForeignKey(b => b.TableId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Bill>()
            .HasMany(b => b.Items)
            .WithOne(i => i.Bill)
            .HasForeignKey(i => i.BillId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Bill>()
            .HasIndex(b => b.TableId)
            .IsUnique()
            .HasFilter("[Status] = 1");
    }
}