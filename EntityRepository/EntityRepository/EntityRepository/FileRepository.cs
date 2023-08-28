using System.Reflection;
using Newtonsoft.Json;

namespace EntityRepository;

public class FileRepository<T> : IRepository<T> where T : IEntity
{
  #region Поля и свойства

  private string path =
    Path.Combine(
      Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
      "Repo.txt");

  #endregion

  #region Методы

  /// <summary>
  /// Прочитать все сущности из файла.
  /// </summary>
  public List<T> ReadAll()
  {
    string fileContent = File.ReadAllText(path);
    return JsonConvert.DeserializeObject<List<T>>(fileContent);
  }

  /// <summary>
  /// Создать сущность в файле.
  /// </summary>
  /// <param name="entity"></param>
  public void Create(T entity)
  {
    List<T> entities = ReadAll();
    if (entities.Contains(entity))
    {
      Console.WriteLine("Already exists");
      return;
    }

    entities.Add(entity);
    string serializedList =
      JsonConvert.SerializeObject(entities, Formatting.Indented);
    File.WriteAllText(path, serializedList);
  }

  /// <summary>
  /// Прочитать сущность по идентификатору из файла.
  /// </summary>
  /// <param name="Id">Идентификатор.</param>
  /// <returns></returns>
  public T Read(int Id)
  {
    List<T> entities = ReadAll();
    T foundEntity = entities.FirstOrDefault(e => e.Id.Equals(Id));
    return foundEntity;
  }

  /// <summary>
  /// Обновить сущность по заданному идентификатору.
  /// </summary>
  /// <param name="idEntityToUpdate">Идентификатор.</param>
  /// <param name="newEntity">Обновленная сущность.</param>
  public void Update(int idEntityToUpdate, T newEntity)
  {
    List<T> entities = ReadAll();
    int indexToFindEntity = entities.FindIndex(e => e.Id == idEntityToUpdate);

    entities.RemoveAt(indexToFindEntity);
    newEntity.Id = idEntityToUpdate;

    entities.Add(newEntity);

    string serializedList =
      JsonConvert.SerializeObject(entities, Formatting.Indented);

    File.WriteAllText(path, serializedList);
  }

  /// <summary>
  /// Удалить сущность.
  /// </summary>
  /// <param name="entity">Сущность для удаления.</param>
  public void Delete(T entity)
  {
    List<T> entities = ReadAll();
    int index = entities.IndexOf(entity);
    entities.RemoveAt(index);
    string serializedList =
      JsonConvert.SerializeObject(entities, Formatting.Indented);
    File.WriteAllText(path, serializedList);
  }

  #endregion

  public FileRepository()
  {
    if (!File.Exists(path))
      File.Create(path);
  }
}
