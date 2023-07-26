using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PhonebookSQL;

public class PhonebookContext : DbContext
{
  public PhonebookContext(DbContextOptions<PhonebookContext> options)
    : base(options)
  {
  }
  
  //CreateDbContext в IDesignTimeDbContextFactory<> автоматически вызывается Entity Framework Core
  //во время выполнения операций, которые требуют взаимодействия с базой данных в дизайн-времени.
  public class PhonebookContextFactory : IDesignTimeDbContextFactory<PhonebookContext>
  {
    public PhonebookContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<PhonebookContext>();
      optionsBuilder.UseNpgsql("Host=localhost;Database=testdb;Username=postgres;Password=8313");

      return new PhonebookContext(optionsBuilder.Options);
    }
  }
  
  // Поле коллекции абонентов типа DbSet.
  public DbSet<Subscriber> Subscribers { get; set; } = null!;
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Subscriber>()
      .HasKey(s => s.Number);
  }
  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=8313");
    //Для установки подключения к базе данных в методе OnConfiguring вызывается метод UseNpgsql(), в который передается строка подключения.
    
  }

}
