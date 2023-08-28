namespace EntityRepository;

public class DbRepository : IRepository<Entity>

{
  #region Поля и свойства

  /// <summary>
  /// Контекст базы данных.
  /// </summary>
  private DbEntityContext db;

  #endregion

  #region Методы

  /// <summary>
  /// Читает объекты из бд и выводит в консоль.
  /// </summary>
  public List<Entity> ReadAll()
  {
    var entities = db.Entities.ToList();
    return entities;
  }

  /// <summary>
  /// Создает сущность.
  /// </summary>
  /// <param name="entity"></param>
  public void Create(Entity entity)
  {
    db.Entities.Add(entity);
    db.SaveChanges();
  }

  /// <summary>
  /// Читает сущность из БД.
  /// </summary>
  /// <param name="id">Идентификатор.</param>
  /// <returns></returns>
  public Entity Read(int id)
  {
    Entity findedEntity = db.Entities.FirstOrDefault(e => e.Id.Equals(id));
    return findedEntity;
  }

  /// <summary>
  /// Обновляет сущность по заданному идентификатору.
  /// </summary>
  /// <param name="idEntityToUpdate">Идентификатор сущности для обновления.</param>
  /// <param name="idEntity2">Обновленная сущность.</param>
  public void Update(int idEntityToUpdate, Entity idEntity2)
  {
    int tempid = idEntityToUpdate;
    Entity entity = db.Entities.First(e => e.Equals(idEntityToUpdate));
    db.Entities.Remove(entity);
    idEntity2.Id = tempid;
    db.SaveChanges();
  }

  /// <summary>
  /// Удалить сущность.
  /// </summary>
  /// <param name="entity">Сущность для удаления.</param>
  public void Delete(Entity entity)
  {
    db.Entities.Remove(entity);
    db.SaveChanges();
  }

  #endregion

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="dbContext">Контекст БД.</param>
  public DbRepository(DbEntityContext dbContext)
  {
    db = dbContext;
  }
}
