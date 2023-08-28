namespace EntityRepository;

public class MemoryRepository<T> : IRepository<T> where T : IEntity
{
  #region Поля и свойства

  private static int count = 0;
  public List<T> list;

  #endregion

  #region Методы

  /// <summary>
  /// Прочитать все.
  /// </summary>
  /// <returns></returns>
  public List<T> ReadAll()
  {
    return list;
  }

  /// <summary>
  /// Создать сущность в памяти.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  public void Create(T entity)
  {
    list.Add(entity);
  }

  /// <summary>
  /// Прочитать сущность.
  /// </summary>
  /// <param name="id">Идентификатор.</param>
  /// <returns></returns>
  public T Read(int id)
  {
    T findedEntity = list.FirstOrDefault(e => e.Id.Equals(id));
    return findedEntity;
  }

  /// <summary>
  /// Обновить сущность в памяти.
  /// </summary>
  /// <param name="idEntityToUpdate">Идентификатор.</param>
  /// <param name="idEntity2">Сущность.</param>
  public void Update(int idEntityToUpdate, T idEntity2)
  {
    int tempid = idEntityToUpdate;
    int indexToFindEntity = list.FindIndex(e => e.Equals(idEntityToUpdate));
    list.RemoveAt(indexToFindEntity);
    idEntity2.Id = tempid;
  }

  /// <summary>
  /// Удалить сущность.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  public void Delete(T entity)
  {
    int index = list.IndexOf(entity);
    list.RemoveAt(index);
  }

  #endregion

  public MemoryRepository()
  {
    list = new List<T>();
  }
}
