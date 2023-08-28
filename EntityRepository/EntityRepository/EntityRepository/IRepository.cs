namespace EntityRepository;

public interface IRepository<T> where T : IEntity
{
  /// <summary>
  /// Прочитать все.
  /// </summary>
  /// <returns></returns>
  List<T> ReadAll();
  
  /// <summary>
  /// Создать сущность.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  void Create(T entity);

  /// <summary>
  /// Прочитать сущность по идентификатору.
  /// </summary>
  /// <param name="id">Идентификатор.</param>
  /// <returns></returns>
  T Read(int id);

  /// <summary>
  /// Обновить сущность.
  /// </summary>
  /// <param name="id">Идентификатор.</param>
  /// <param name="entity">Сущность.</param>
  void Update(int id, T entity);

  /// <summary>
  /// Удалить сущность.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  void Delete(T entity);
}
