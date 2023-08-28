using Microsoft.EntityFrameworkCore;

namespace EntityRepository;

public class DbEntityContext : DbContext
{
  /// <summary>
  /// Поле коллекции сущностей типа DbSet в БД.
  /// </summary>
  public DbSet<Entity> Entities { get; set; }

  /// <summary>
  /// Настраивает модель сущностей в БД по первичному ключу - Id.
  /// </summary>
  /// <param name="modelBuilder">Создатель модели для настройки моделей БД.</param>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Entity>()
      .HasKey(s => s.Id);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql(
      "Host=localhost;Port=5432;Database=testdb2;Username=postgres;Password=8313");
  }

  /// <summary>
  /// Конструктор класса контекста базы данных.
  /// </summary>
  /// <param name="options">Опции настройки.</param>
  public DbEntityContext()
  {
  }
}
