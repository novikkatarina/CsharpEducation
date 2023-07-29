using Microsoft.EntityFrameworkCore;

namespace PhonebookSQL;

/// <summary>
/// Класс контекста данных.
/// </summary>
public class PhonebookContext : DbContext
{
  /// <summary>
  /// Поле коллекции абонентов типа DbSet в БД.
  /// </summary>
  public DbSet<Subscriber> Subscribers { get; set; } = null!;

  /// <summary>
  /// Настраивает модель сущностей в БД по первичному ключу - номеру.
  /// </summary>
  /// <param name="modelBuilder">Создатель модели для настройки моделей БД.</param>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Subscriber>()
      .HasKey(s => s.Number);
  }

  /// <summary>
  /// Задает опции для подключения к базе данных, где вызывается метод UseNpgsql(), в который передается строка подключения.
  /// </summary>
  /// <param name="optionsBuilder"></param>
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql(
      "Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=8313");
  }

  /// <summary>
  /// Конструктор класса контекста базы данных.
  /// </summary>
  /// <param name="options">Опции настройки.</param>
  public PhonebookContext(DbContextOptions<PhonebookContext> options)
    : base(options)
  {
  }
}
